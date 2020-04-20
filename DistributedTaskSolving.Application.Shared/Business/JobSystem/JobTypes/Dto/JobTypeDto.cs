using DistributedTaskSolving.Application.Shared.Generics;
using DistributedTaskSolving.Application.Shared.Generics.Dto;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto
{
    public class JobTypeDto : FullAuditedEntityDto<string>
    {
        public string Description { get; set; }
    }
}