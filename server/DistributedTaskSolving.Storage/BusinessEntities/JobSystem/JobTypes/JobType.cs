using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public JobInstance CreateJobInstance()
        {
            var jobInstance = new JobInstance();

            switch (Name)
            {
                case JobTypeEnums.WordGuessing:
                    jobInstance.Key = "slowo";
                    break;
                case JobTypeEnums.MonteCarlo:
                    jobInstance.Key = "10000";
                    break;
                case JobTypeEnums.PasswordBruteForcing:
                    jobInstance.Key = "P@ssw0rd!";
                    break;
            }

            JobInstances ??= new List<JobInstance>();
            JobInstances.Add(jobInstance);

            return jobInstance;
        }
    }
}