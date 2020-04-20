using System;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace DistributedTaskSolving.Application.Business.JobSystem.Hubs
{
    public class JobSystemHub : Hub
    {
        private readonly IRepository<WorkUnit, long> _workUnitRepository;

        public JobSystemHub(IRepository<WorkUnit, long> workUnitRepository)
        {
            _workUnitRepository = workUnitRepository;
        }


        public override async Task OnConnectedAsync()
        {
            //await Groups.AddToGroupAsync(Context.ConnectionId, GetGroupName());
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
           // await Groups.RemoveFromGroupAsync(Context.ConnectionId, GetGroupName());
        }
    }
}