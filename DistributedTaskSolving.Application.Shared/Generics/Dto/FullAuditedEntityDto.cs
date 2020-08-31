using System;

namespace DistributedTaskSolving.Application.Shared.Generics.Dto
{
    public class FullAuditedEntityDto<TPrimaryKey> : CreationAuditedEntityDto<TPrimaryKey>
    {
        public string LastModifierUserName { get; set; }
        public DateTime? LastModificationDateTime { get; set; }
    }
}