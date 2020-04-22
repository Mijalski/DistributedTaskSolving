using System;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms
{
    public class AlgorithmDto : FullAuditedEntityDto<long>
    {
        public string Name { get; set; }
        public byte[] Code { get; set; }
        public Guid JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}