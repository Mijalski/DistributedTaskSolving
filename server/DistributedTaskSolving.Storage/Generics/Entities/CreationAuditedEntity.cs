using System;
using DistributedTaskSolving.Business.IGenerics.Entities;
using Microsoft.AspNetCore.Identity;

namespace DistributedTaskSolving.Business.Generics.Entities
{
    public class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAuditedEntity
    {
        public IdentityUser CreatorUser { get; set; }
        public DateTime CreationDateTime { get; set; }
    }

    public class CreationAuditedEntity : CreationAuditedEntity<long>
    {
    }
}