using System;
using DistributedTaskSolving.Application.Generics.Endpoints;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes
{
    public class JobTypeEndpoint : QueryEndpoint<JobType, Guid, JobTypeDto, string>
    {
        public JobTypeEndpoint(
            IQueryService<JobType, Guid, JobTypeDto, string> queryService)
            : base(queryService)
        {
        }
    }
}