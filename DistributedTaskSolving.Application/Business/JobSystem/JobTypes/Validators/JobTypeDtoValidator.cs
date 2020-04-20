using System;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.Validators
{
    public class JobTypeDtoValidator : AbstractValidator<JobTypeDto>
    {
        public JobTypeDtoValidator(IRepository<JobType, Guid> repository)
        {
            RuleFor(_ => _.Id).NotEmpty();
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().SingleOrDefaultAsync(_ => _.Name == id);
                return exists == null;
            }).WithMessage("Job Type with this name already exists!");
        }
    }
}