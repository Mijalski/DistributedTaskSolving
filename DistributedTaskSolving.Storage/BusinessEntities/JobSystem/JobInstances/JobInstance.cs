using System;
using System.Collections.Generic;
using System.Text.Json;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances
{
    public class JobInstance : FullAuditedEntity<long>, ISoftDelete
    {
        public JobInstance()
        {
            WorkUnits = new List<WorkUnit>();
        }

        private SequencingJobInstanceJson _keyObject;

        public string Key { get; set; }
        public string Result { get; set; }
        public bool IsSolved { get; set; }
        public virtual ICollection<WorkUnit> WorkUnits { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
        public Guid JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public DateTime? FinishDateTime { get; set; }

        internal SequencingJobInstanceJson GetKeyObject()
        {
            return _keyObject ??= JsonSerializer.Deserialize<SequencingJobInstanceJson>(Key);
        }
    }
}