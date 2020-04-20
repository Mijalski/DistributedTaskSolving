using System.Linq;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandServices
{
    public class AlgorithmQueryService : QueryService<Algorithm, long, AlgorithmDto, string>
    {
        public AlgorithmQueryService(IRepository<Algorithm, long> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override IQueryable<Algorithm> ConfigureIncludes()
        {
            return base.ConfigureIncludes()
                .Include(_ => _.JobType)
                .Include(_ => _.ProgrammingLanguage);
        }
    }
}