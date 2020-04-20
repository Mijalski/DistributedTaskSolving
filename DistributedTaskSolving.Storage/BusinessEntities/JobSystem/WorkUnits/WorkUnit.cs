using System;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits
{
    public class WorkUnit : CreationAuditedEntity, ISoftDelete, IHaveUniqueName<long>
    {
        public long JobInstanceId { get; set; }
        public JobInstance JobInstance { get; set; }
        public string DataIn { get; set; }
        public string DataOut { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
        public long Name { get; set; }
    }
}