using DistributedTaskSolving.Application.Business.ProgrammingLanguages.CommandHandlers;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.Validators
{
    public class UpdateProgrammingLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValidator(IRepository<ProgrammingLanguage, int> repository)
        {
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
                return exists != null;
            }).WithMessage("Job Type with this ID does not exist");
        }
    }
}