using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.JobInstanceCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs
{
    public class JobInstanceHub : Hub, IJobInstanceHub
    {
        private readonly IRepository<WorkUnit, long> _workUnitRepository;
        private readonly IRepository<JobInstance, long> _jobInstanceRepository;
        private readonly IRepository<JobType, Guid> _jobTypeRepository;
        private readonly IRepository<Algorithm, long> _algorithmRepository;
        private readonly IRepository<ProgrammingLanguage, int> _programmingLanguageRepository;
        private readonly WorkUnitCreatorServiceResolver _workUnitCreatorServiceResolver;
        private readonly WorkUnitFinisherServiceResolver _workUnitFinisherServiceResolver;
        private readonly JobInstanceCreatorServiceResolver _jobInstanceCreatorServiceResolver;
        private readonly ILogger<JobInstanceHub> _logger;
        private static JobInstance _jobInstance;
        private static SemaphoreSlim _jobInstanceSemaphore = new SemaphoreSlim(1, 1);

        public JobInstanceHub(IRepository<WorkUnit, long> workUnitRepository,
            IRepository<JobInstance, long> jobInstanceRepository,
            IRepository<JobType, Guid> jobTypeRepository,
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository,
            IRepository<Algorithm, long> algorithmRepository,
            WorkUnitCreatorServiceResolver workUnitCreatorServiceResolver,
            WorkUnitFinisherServiceResolver workUnitFinisherServiceResolver,
            JobInstanceCreatorServiceResolver jobInstanceCreatorServiceResolver,
            ILogger<JobInstanceHub> logger)
        {
            _workUnitRepository = workUnitRepository;
            _jobInstanceRepository = jobInstanceRepository;
            _jobTypeRepository = jobTypeRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
            _algorithmRepository = algorithmRepository;
            _workUnitCreatorServiceResolver = workUnitCreatorServiceResolver;
            _workUnitFinisherServiceResolver = workUnitFinisherServiceResolver;
            _jobInstanceCreatorServiceResolver = jobInstanceCreatorServiceResolver;
            _logger = logger;
        }

        public async Task StartWorkOnJobType(string jobTypeName, WorkUnitClientDto workUnitClientDto,
            string algorithmName, string programmingLanguageName)
        {
            await _jobInstanceSemaphore.WaitAsync();

            var oldestUnfinishedJobInstanceId = 0L;

            try
            {
                oldestUnfinishedJobInstanceId = await _jobInstanceRepository
                            .GetAll()
                            .Where(_ => !_.IsSolved && _.JobType.Name == jobTypeName)
                            .OrderByDescending(_ => _.CreationDateTime)
                            .Select(i => i.Id)
                            .FirstOrDefaultAsync();

                if (oldestUnfinishedJobInstanceId == 0)
                {
                    oldestUnfinishedJobInstanceId = await CreateJobInstance(jobTypeName);
                }
            }
            finally
            {
                _jobInstanceSemaphore.Release();
            }

            var workUnit = await CreateWorkUnit(oldestUnfinishedJobInstanceId, workUnitClientDto, jobTypeName);

            if (workUnit != null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveWorkUnit", workUnit.Id, workUnit.DataIn, workUnit.JobInstanceId);
            }
            else
            {
                //retry
                await Task.Delay(5000);
                await StartWorkOnJobType(jobTypeName, workUnitClientDto, algorithmName, programmingLanguageName);
            }
        }

        public async Task FinishWorkUnit(long workUnitId, string data, bool isSolved, string jobTypeName, double executionTimeInMs)
        {
            try
            {
                var workUnit = await _workUnitRepository
                    .GetAll()
                    .FirstOrDefaultAsync(_ => _.Id == workUnitId);

                var workUnitFinisher = _workUnitFinisherServiceResolver(jobTypeName);

                workUnit.ExecutionTimeInMs = executionTimeInMs;
                var isJobInstanceFinished = await workUnitFinisher.FinishWorkUnitAsync(workUnit, data, isSolved);

                if (isJobInstanceFinished)
                {
                    var jobInstance = await _jobInstanceRepository
                        .GetAll()
                        .Include(i => i.WorkUnits)
                        .FirstAsync(i => i.Id == workUnit.JobInstanceId);
                    workUnitFinisher.FinishJobInstance(jobInstance);
                    await _jobInstanceRepository.UpdateAsync(jobInstance);
                    await _jobInstanceRepository.SaveChangesAsync();
                }

                await _workUnitRepository.UpdateAsync(workUnit);
                await _workUnitRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception during FinishWorkUnit");
            }
        }

        private async Task<long> CreateJobInstance(string jobTypeName)
        {
            var jobInstanceCreator = _jobInstanceCreatorServiceResolver(jobTypeName);

            var jobType = await _jobTypeRepository
                .GetAll()
                .FirstOrDefaultAsync(_ => _.Name == jobTypeName);

            var jobInstance = jobInstanceCreator.CreateJobInstance(jobType);

            await _jobInstanceRepository.UpdateAsync(jobInstance);
            await _jobInstanceRepository.SaveChangesAsync();

            return jobInstance.Id;
        }

        private async Task<WorkUnit> CreateWorkUnit(long jobInstanceId, WorkUnitClientDto workUnitClientDto, string jobTypeName)
        {
            var workUnitCreator = _workUnitCreatorServiceResolver(jobTypeName);

            var workUnit = await workUnitCreator.CreateWorkUnitAsync(jobInstanceId, null, null);

            if (workUnit == null)
            {
                await _workUnitRepository.SaveChangesAsync();

                return null;
            }

            workUnit.WorkUnitClient = new WorkUnitClient
            {
                UserAgent = workUnitClientDto.UserAgent,
                RamSize = workUnitClientDto.RamSize
            };
            workUnit.ConnectionId = Context.ConnectionId;

            await _workUnitRepository.UpdateAsync(workUnit);
            await _workUnitRepository.SaveChangesAsync();

            return workUnit;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            var workUnits =
                await _workUnitRepository.GetAll().Include(u => u.JobInstance).ThenInclude(i => i.JobType).Where(u => u.ConnectionId == Context.ConnectionId && !u.IsSolved).ToListAsync();

            foreach (var workUnit in workUnits)
            {
                workUnit.IsAbandoned = true;

                var workUnitFinisher = _workUnitFinisherServiceResolver(workUnit.JobInstance.JobType.Name);

                workUnitFinisher.FinishAbandonedWorkUnit(workUnit);
                await _workUnitRepository.UpdateAsync(workUnit);
            }

            await _workUnitRepository.SaveChangesAsync();
            await base.OnDisconnectedAsync(e);
        }

        private string GetGroupName(long jobInstanceId)
        {
            return $"{JobInstanceEnums.JobInstanceHubGroupPrefix}{jobInstanceId}";
        }
    }
}