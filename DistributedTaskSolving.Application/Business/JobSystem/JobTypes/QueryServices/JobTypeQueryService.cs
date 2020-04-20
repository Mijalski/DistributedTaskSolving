using System;
using System.Linq;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.QueryServices
{
    public class JobTypeQueryService : QueryService<JobType, Guid, JobTypeDto, string>
    {
        public JobTypeQueryService(IRepository<JobType, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override IQueryable<JobType> ConfigureIncludes()
        {
            return base.ConfigureIncludes()
                .Include(_ => _.Algorithms).ThenInclude(_ => _.ProgrammingLanguage);
        }
    }
}