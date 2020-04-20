using System;
using System.Linq;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandServices
{
    public class JobInstanceQueryService : QueryService<JobInstance, long, JobInstanceDto, long>
    {
        public JobInstanceQueryService(IRepository<JobInstance, long> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override IQueryable<JobInstance> ConfigureIncludes()
        {
            return base.ConfigureIncludes()
                .Include(_ => _.Algorithm).ThenInclude(_ => _.JobType);
        }
    }
}