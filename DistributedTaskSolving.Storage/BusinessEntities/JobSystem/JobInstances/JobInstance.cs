using System;
using System.Collections.Generic;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.Tenants;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances
{
    public class JobInstance : FullAuditedEntity<long>, ISoftDelete, IHaveUniqueName<long>
    {
        public JobInstance()
        {
            WorkUnits = new List<WorkUnit>();
        }
        public string Key { get; set; }
        public string Result { get; set; }
        public bool IsSolved { get; set; }
        public long AlgorithmId { get; set; }
        public virtual Algorithm Algorithm { get; set; }
        public virtual ICollection<WorkUnit> WorkUnits { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }

        public long Name
        {
            get => Id;
            set => Id = value;
        }
    }
}