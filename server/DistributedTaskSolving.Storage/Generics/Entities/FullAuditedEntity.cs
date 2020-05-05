using System;
using DistributedTaskSolving.Business.IGenerics.Entities;
using Microsoft.AspNetCore.Identity;

namespace DistributedTaskSolving.Business.Generics.Entities
{
    public class FullAuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey> , IModificationAuditedEntity
    {
        public IdentityUser LastModifierUser { get; set; }
        public DateTime? LastModificationDateTime { get; set; }
    }

    public class FullAuditedEntity : FullAuditedEntity<long>
    {
    }
}