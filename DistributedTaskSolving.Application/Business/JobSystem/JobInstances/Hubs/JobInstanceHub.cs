using System;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs
{
    public class JobInstanceHub : Hub
    {
        private readonly IRepository<WorkUnit, long> _workUnitRepository;
        private readonly IRepository<JobInstance, long> _jobInstanceRepository;
        private readonly IRepository<JobType, Guid> _jobTypeRepository;

        public JobInstanceHub(IRepository<WorkUnit, long> workUnitRepository, 
            IRepository<JobInstance, long> jobInstanceRepository, 
            IRepository<JobType, Guid> jobTypeRepository)
        {
            _workUnitRepository = workUnitRepository;
            _jobInstanceRepository = jobInstanceRepository;
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task StartWorkOnJobType(Guid jobTypeId)
        {
            var job = await _jobTypeRepository
                .GetAll()
                .Include(_ => _.JobInstances)
                .SingleOrDefaultAsync(_ => _.Id == jobTypeId);

            var oldestUnfinishedJobInstance = job.JobInstances
                .Where(_ => !_.IsSolved)
                .OrderByDescending(_ => _.CreationDateTime)
                .FirstOrDefault();

            if (oldestUnfinishedJobInstance == null)
            {
                //TODO Create new job instance of this type and start working on it
                throw new NotImplementedException();
            }

            var workUnit = await CreateWorkUnit(oldestUnfinishedJobInstance);
            await Clients.Client(Context.ConnectionId).SendCoreAsync("OnStartWork", new object[] { workUnit.DataIn });
        }

        public async Task StartWorkOnJobInstance(long jobInstanceId)
        {
            var jobInstance = await _jobInstanceRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Id == jobInstanceId);

            if (jobInstance == null)
            {
                throw new ArgumentException("Job Instance with this ID does not exist!");
            }

            if (jobInstance.IsSolved)
            {
                await Clients.Client(Context.ConnectionId).SendCoreAsync("OnWorkCompleted", new object[] {});
            }

            var workUnit = await CreateWorkUnit(jobInstance);
            await Clients.Client(Context.ConnectionId).SendCoreAsync("OnStartWork", new object[] { workUnit.DataIn });
        }

        public async Task StartWork()
        {
            var jobInstance = await _jobInstanceRepository
                .GetAll()
                .Where(_ => !_.IsSolved)
                .OrderByDescending(_ => _.CreationDateTime)
                .FirstAsync();

            var workUnit = await CreateWorkUnit(jobInstance);
            await Clients.Client(Context.ConnectionId).SendCoreAsync("ReceiveWorkUnit", new object[] { workUnit.DataIn });
        }

        private async Task<WorkUnit> CreateWorkUnit(JobInstance jobInstance)
        {
            var workUnit = jobInstance.CreateWorkUnit();
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