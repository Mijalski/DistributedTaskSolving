using System;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Validators
{
    public class JobInstanceDtoValidator : AbstractValidator<JobInstanceDto>
    {
        public JobInstanceDtoValidator(IRepository<JobInstance, long> repository,
            IRepository<Algorithm, long> algorithmRepository)
        {
            RuleFor(_ => _.AlgorithmName).MustAsync(async (id, cancellation) =>
            {
                var exists = await algorithmRepository.GetAll().SingleOrDefaultAsync(_ => _.Name == id);
                return exists != null;
            }).WithMessage("Algorithm with this name does not exist!");
        }
    }
}