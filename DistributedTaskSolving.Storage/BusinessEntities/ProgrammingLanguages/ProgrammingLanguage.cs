using System;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages
{
    public class ProgrammingLanguage : CreationAuditedEntity<int>, ISoftDelete, IHaveUniqueName<string>
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
        public string Name { get; set; }
    }
}