using System;
using Microsoft.AspNetCore.Identity;

namespace DistributedTaskSolving.Business.IGenerics.Entities
{
    public interface ICreationAuditedEntity
    {
        public IdentityUser CreatorUser { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}