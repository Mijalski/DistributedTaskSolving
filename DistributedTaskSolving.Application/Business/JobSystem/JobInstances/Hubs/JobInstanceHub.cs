using System;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs
{
    public class JobInstanceHub : Hub, IJobInstanceHub
    {
        private readonly IRepository<WorkUnit, long> _workUnitRepository;
        private readonly IRepository<JobInstance, long> _jobInstanceRepository;
        private readonly IRepository<JobType, Guid> _jobTypeRepository;
        private readonly IRepository<Algorithm, long> _algorithmRepository;
        private readonly IRepository<ProgrammingLanguage, int> _programmingLanguageRepository;

        public JobInstanceHub(IRepository<WorkUnit, long> workUnitRepository, 
            IRepository<JobInstance, long> jobInstanceRepository, 
            IRepository<JobType, Guid> jobTypeRepository, 
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository, 
            IRepository<Algorithm, long> algorithmRepository)
        {
            _workUnitRepository = workUnitRepository;
            _jobInstanceRepository = jobInstanceRepository;
            _jobTypeRepository = jobTypeRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
            _algorithmRepository = algorithmRepository;
        }

        public async Task StartWorkOnJobType(string jobTypeName, string algorithmName, string programmingLanguageName)
        {
            var jobType = await _jobTypeRepository
                .GetAll()
                .Include(_ => _.JobInstances)
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
                .SingleOrDefaultAsync(_ => _.Id == workUnitId);

            workUnit.CompleteWorkUnit(data, isSolved);
        }

        private async Task<JobInstance> CreateJobInstance(JobType jobType)
        {
            var jobInstance = jobType.CreateJobInstance();

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

            var workUnit = jobInstance.CreateWorkUnit(algorithm, programmingLanguage);

            await _jobInstanceRepository.UpdateAsync(jobInstance);
            await _jobInstanceRepository.SaveChangesAsync();

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