using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages
{
    public class ProgrammingLanguageDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }

    }
}