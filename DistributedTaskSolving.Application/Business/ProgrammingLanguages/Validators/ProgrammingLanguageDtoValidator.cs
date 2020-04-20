using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.Validators
{
    public class ProgrammingLanguageDtoValidator : AbstractValidator<ProgrammingLanguageDto>
    {
        public ProgrammingLanguageDtoValidator(IRepository<ProgrammingLanguage, int> repository)
        {
            RuleFor(_ => _.Id).NotEmpty();
            RuleFor(_ => _.Id).MustAsync(async (id, cancellation) =>
            {
                var exists = await repository.GetAll().SingleOrDefaultAsync(_ => _.Name == id);
                return exists == null;
            }).WithMessage("Programming Language with this name already exists!");
        }
    }
}