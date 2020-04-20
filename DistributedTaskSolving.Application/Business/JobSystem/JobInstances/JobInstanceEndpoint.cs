using System;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Endpoints;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances
{
    public class JobInstanceEndpoint : QueryEndpoint<JobInstance, long, JobInstanceDto, long>
    {
        public JobInstanceEndpoint(
            IQueryService<JobInstance, long, JobInstanceDto, long> queryService)
            : base(queryService)
        {
        }
    }
}