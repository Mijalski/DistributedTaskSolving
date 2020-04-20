using System;
using System.Collections.Generic;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.Tenants
{
    public class Tenant : FullAuditedEntity<int>, ISoftDelete, IHaveUniqueName<string>
    {
        public Tenant()
        {
            JobInstances = new List<JobInstance>();
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiKeyHash { get; set; }
        public virtual ICollection<JobInstance> JobInstances { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
    }
}