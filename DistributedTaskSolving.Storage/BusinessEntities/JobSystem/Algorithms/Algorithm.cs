using System;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms
{
    public class Algorithm : FullAuditedEntity, ISoftDelete
    {
        public byte[] Code { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
        public string Name { get; set; }
        public Guid JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}