using DistributedTaskSolving.Application.Shared.Generics.Dto;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms
{
    public class AlgorithmDto : FullAuditedEntityDto<string>
    {
        public byte[] Code { get; set; }
        public string JobTypeName { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}