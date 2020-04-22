using System;
using DistributedTaskSolving.Application.Shared.Generics.Dto;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto
{
    public class JobTypeDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}