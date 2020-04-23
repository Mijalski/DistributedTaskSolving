using System;
using DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandHandlers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.Validators
{
    public class UpdateAlgorithmValidator : AbstractValidator<UpdateAlgorithmCommand>
    {
        public UpdateAlgorithmValidator(IRepository<Algorithm, long> repository,
            IRepository<JobType, Guid> jobTypeRepository,
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository)
        {
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Algorithm with this ID does not exist");
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.JobTypeId).MustAsync(async (id, cancellation) =>
            {
                var exists = await jobTypeRepository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Job Type with this ID does not exist!");
            RuleFor(_ => _.ProgrammingLanguageId).MustAsync(async (id, cancellation) =>
            {
                var exists = await programmingLanguageRepository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Programming Language with this ID does not exist!");
        }
    }
}