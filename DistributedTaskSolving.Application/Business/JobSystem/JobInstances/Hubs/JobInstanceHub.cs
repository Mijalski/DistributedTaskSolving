using System;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances;
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

        public JobInstanceHub(IRepository<WorkUnit, long> workUnitRepository, 
            IRepository<JobInstance, long> jobInstanceRepository, 
            IRepository<JobType, Guid> jobTypeRepository, 
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository, 
            IRepository<Algorithm, long> algorithmRepository,
            WorkUnitCreatorServiceResolver workUnitCreatorServiceResolver, 
            WorkUnitFinisherServiceResolver workUnitFinisherServiceResolver, 
            JobInstanceCreatorServiceResolver jobInstanceCreatorServiceResolver)
        {
            _workUnitRepository = workUnitRepository;
            _jobInstanceRepository = jobInstanceRepository;
            _jobTypeRepository = jobTypeRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
            _algorithmRepository = algorithmRepository;
            _workUnitCreatorServiceResolver = workUnitCreatorServiceResolver;
            _workUnitFinisherServiceResolver = workUnitFinisherServiceResolver;
            _jobInstanceCreatorServiceResolver = jobInstanceCreatorServiceResolver;
        }

        public async Task StartWorkOnJobType(string jobTypeName, string algorithmName, string programmingLanguageName)
        {
            var jobType = await _jobTypeRepository
                .GetAll()
                .Include(_ => _.JobInstances)
                    .ThenInclude(_ => _.WorkUnits)
                .SingleOrDefaultAsync(_ => _.Name == jobTypeName);

            var oldestUnfinishedJobInstance = jobType
                .JobInstances
                .Where(_ => !_.IsSolved)
                .OrderByDescending(_ => _.CreationDateTime)
                .FirstOrDefault() ?? await CreateJobInstance(jobType);

            var workUnit = await CreateWorkUnit(oldestUnfinishedJobInstance, algorithmName, programmingLanguageName);

            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveWorkUnit", workUnit.Id, workUnit.DataIn);
        }

        public async Task FinishWorkUnit(long workUnitId, string data, bool isSolved)
        {
            var workUnit = await _workUnitRepository
                .GetAll()
                .Include(_ => _.JobInstance)
                    .ThenInclude(_ => _.JobType)
                .SingleOrDefaultAsync(_ => _.Id == workUnitId);

            var workUnitFinisher = _workUnitFinisherServiceResolver(workUnit.JobInstance.JobType.Name);

            workUnitFinisher.FinishWorkUnit(workUnit, data, isSolved);

            await _workUnitRepository.UpdateAsync(workUnit);
            await _workUnitRepository.SaveChangesAsync();
        }

        private async Task<JobInstance> CreateJobInstance(JobType jobType)
        {
            var jobInstanceCreator = _jobInstanceCreatorServiceResolver(jobType.Name);

            var jobInstance = jobInstanceCreator.CreateJobInstance(jobType);

            await _jobInstanceRepository.UpdateAsync(jobInstance);
            await _jobInstanceRepository.SaveChangesAsync();

            return jobInstance;
        }

        private async Task<WorkUnit> CreateWorkUnit(JobInstance jobInstance, string algorithmName = null, string programmingLanguageName = null)
        {
            var algorithm = await _algorithmRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Name == algorithmName);
            var programmingLanguage = await _programmingLanguageRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Name == programmingLanguageName);

            var workUnitCreator = _workUnitCreatorServiceResolver(jobInstance.JobType.Name);

            var workUnit = workUnitCreator.CreateWorkUnit(jobInstance, algorithm, programmingLanguage);

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
            await base.OnDisconnectedAsync(e);
        }

        private string GetGroupName(long jobInstanceId)
        {
            return $"{JobInstanceEnums.JobInstanceHubGroupPrefix}{jobInstanceId}";
        }
    }
}