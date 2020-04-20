using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using FluentValidation;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.Validators
{
    public class WorkUnitDtoValidator : AbstractValidator<WorkUnitDto>
    {
        public WorkUnitDtoValidator()
        {
        }
    }
}