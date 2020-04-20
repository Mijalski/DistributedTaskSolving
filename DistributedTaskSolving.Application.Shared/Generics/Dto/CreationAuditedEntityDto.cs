using System;

namespace DistributedTaskSolving.Application.Shared.Generics.Dto
{
    public class CreationAuditedEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>
    {
        public string CreatorUserName { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}