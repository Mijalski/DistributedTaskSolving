using System;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.Validators
{
    public class AlgorithmDtoValidator : AbstractValidator<AlgorithmDto>
    {
        public AlgorithmDtoValidator(IRepository<Algorithm, long> repository,
            IRepository<JobType, Guid> jobTypeRepository,
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository)
        {
            RuleFor(_ => _.Id).NotEmpty();
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().SingleOrDefaultAsync(_ => _.Name == id);
                return exists == null;
            }).WithMessage("Algorithm with this name already exists!");

            RuleFor(_ => _.JobTypeName).MustAsync(async (id, cancellation) =>
            {
                var exists = await jobTypeRepository.GetAll().SingleOrDefaultAsync(_ => _.Name == id);
                return exists != null;
            }).WithMessage("Job Type with this name does not exist!");

            RuleFor(_ => _.ProgrammingLanguageName).MustAsync(async (id, cancellation) =>
            {
                var exists = await programmingLanguageRepository.GetAll().SingleOrDefaultAsync(_ => _.Name == id);
                return exists != null;
            }).WithMessage("Programming Language with this name does not exist!");
        }
    }
}