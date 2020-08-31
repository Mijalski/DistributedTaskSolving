using System;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits
{
    public class WorkUnit : CreationAuditedEntity, ISoftDelete
    {
        public long JobInstanceId { get; set; }
        public JobInstance JobInstance { get; set; }
        public long? AlgorithmId { get; set; }
        public virtual Algorithm Algorithm { get; set; }
        public int? ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public string DataIn { get; set; }
        public string DataOut { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAbandoned { get; set; }
        public DateTime? DeletionDateTime { get; set; }
        public bool IsSolved { get; set; }
        public DateTime? SubmitDateTime { get; set; }
        public long? WorkUnitClientId { get; set; }
        public WorkUnitClient WorkUnitClient { get; set; }
        public string ConnectionId { get; set; }
    }
}