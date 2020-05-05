using System;
using System.Collections.Generic;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
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
        public string Key { get; set; }
        public string Result { get; set; }
        public bool IsSolved { get; set; }
        public virtual ICollection<WorkUnit> WorkUnits { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDateTime { get; set; }
        public Guid JobTypeId { get; set; }
        public JobType JobType { get; set; }

        public WorkUnit CreateWorkUnit(Algorithm algorithm = null, ProgrammingLanguage programmingLanguage = null)
        {
            var workUnit = new WorkUnit
            {
                JobInstance = this, 
                Algorithm = algorithm,
                ProgrammingLanguage = programmingLanguage
            };

            //TODO Implement some kind of mutex system so that one batch of data is given to one work unit
            switch (JobType.Name)
            {
                case JobTypeEnums.WordGuessing:
                    workUnit.DataIn = "aaaa-gggg";
                    break;
                case JobTypeEnums.MonteCarlo:
                    workUnit.DataIn = "500";
                    break;
                case JobTypeEnums.PasswordBruteForcing:
                    workUnit.DataIn = "aaa-ggg";
                    break;
            }

            WorkUnits ??= new List<WorkUnit>();
            WorkUnits.Add(workUnit);

            return workUnit;
        }
    }
}