using System;
using System.Collections.Generic;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes
{
    public class JobType : FullAuditedEntity<Guid>, ISoftDelete
    {
        public JobType()
        {
            JobInstances = new List<JobInstance>();
            Algorithms = new List<Algorithm>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Algorithm> Algorithms { get; set; }
        public virtual ICollection<JobInstance> JobInstances { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
    }
}