using System;
using Microsoft.AspNetCore.Identity;

namespace DistributedTaskSolving.Business.IGenerics.Entities
{
    public interface IModificationAuditedEntity
    {
        public IdentityUser LastModifierUser { get; set; }
        public DateTime? LastModificationDateTime { get; set; }
    }
}