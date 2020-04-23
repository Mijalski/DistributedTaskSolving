using System;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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

        public async Task StartWorkOnJobType(string jobTypeName)
        {
            var job = await _jobTypeRepository
                .GetAll()
                .Include(_ => _.JobInstances)
                .SingleOrDefaultAsync(_ => _.Name == jobTypeName);

            var oldestUnfinishedJobInstance = job
                .JobInstances
                .Where(_ => !_.IsSolved)
                .OrderByDescending(_ => _.CreationDateTime)
                .FirstOrDefault();

            if (oldestUnfinishedJobInstance == null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", $"Work for job type {job.Name} is finished");
                //TODO Create new job instance of this type and start working on it
                return;
            }

            var workUnit = await CreateWorkUnit(oldestUnfinishedJobInstance);
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveWorkUnit", workUnit.DataIn);
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
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveWorkCompleted");
            }

            var workUnit = await CreateWorkUnit(jobInstance);
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveWorkUnit", workUnit.DataIn);
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