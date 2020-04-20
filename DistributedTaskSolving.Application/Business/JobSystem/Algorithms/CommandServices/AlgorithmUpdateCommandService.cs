using System;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandServices
{
    public class AlgorithmUpdateCommandService : UpdateCommandService<Algorithm, long, AlgorithmDto, string>
    {
        private readonly IRepository<JobType, Guid> _jobTypeRepository;
        private readonly IRepository<ProgrammingLanguage, int> _programmingLanguageRepository;

        public AlgorithmUpdateCommandService(IRepository<Algorithm, long> repository,
            IValidator<AlgorithmDto> validator, 
            IMapper mapper, 
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository, 
            IRepository<JobType, Guid> jobTypeRepository) 
            : base(repository, validator, mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _jobTypeRepository = jobTypeRepository;
        }

        protected override async Task AssignRelatedEntities(Algorithm entity, AlgorithmDto input)
        {
            entity.ProgrammingLanguage = await _programmingLanguageRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Name == input.ProgrammingLanguageName);

            entity.JobType = await _jobTypeRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Name == input.JobTypeName);
        }
    }
}