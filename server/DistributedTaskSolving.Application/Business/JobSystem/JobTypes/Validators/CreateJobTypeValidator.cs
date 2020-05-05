using System;
using DistributedTaskSolving.Application.Business.JobSystem.JobTypes.CommandHandlers;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.Validators
{
    public class CreateJobTypeValidator : AbstractValidator<CreateJobTypeCommand>
    {
        public CreateJobTypeValidator(IRepository<JobType, Guid> repository)
        {
        }
    }
}