using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandServices
{
    public class JobInstanceUpdateCommandService : UpdateCommandService<JobInstance, long, JobInstanceDto, long>
    {
        private readonly IRepository<Algorithm, long> _algorithmRepository;
        public JobInstanceUpdateCommandService(IRepository<JobInstance, long> repository,
            IValidator<JobInstanceDto> validator,
            IMapper mapper, 
            IRepository<Algorithm, long> algorithmRepository)
            : base(repository, validator, mapper)
        {
            _algorithmRepository = algorithmRepository;
        }

        protected override async Task AssignRelatedEntities(JobInstance entity, JobInstanceDto input)
        {
            entity.Algorithm = await _algorithmRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Name == input.JobTypeName);
        }
    }
}