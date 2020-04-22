using System;
using DistributedTaskSolving.Application.Business.JobSystem.JobTypes.CommandHandlers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.Validators
{
    public class UpdateJobTypeValidator : AbstractValidator<UpdateJobTypeCommand>
    {
        public UpdateJobTypeValidator(IRepository<JobType, Guid> repository)
        {
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Job Type with this ID does not exist");
        }
    }
}