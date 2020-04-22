using System;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandHandlers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Validators
{
    public class UpdateJobInstanceValidator : AbstractValidator<UpdateJobInstanceCommand>
    {
        public UpdateJobInstanceValidator(IRepository<JobInstance, long> repository,
            IRepository<Algorithm, long> algorithmRepository)
        {
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Algorithm with this ID does not exist");
            RuleFor(_ => _.AlgorithmId).MustAsync(async (id, cancellation) =>
            {
                var exists = await algorithmRepository.GetAll().SingleOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Algorithm with this ID does not exist!");
        }
    }
}