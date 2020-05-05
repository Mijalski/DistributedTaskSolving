using System;
using DistributedTaskSolving.Application.Business.ProgrammingLanguages.CommandHandlers;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.Validators
{
    public class CreateProgrammingLanguageValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageValidator(IRepository<ProgrammingLanguage, int> repository)
        {
        }
    }
}