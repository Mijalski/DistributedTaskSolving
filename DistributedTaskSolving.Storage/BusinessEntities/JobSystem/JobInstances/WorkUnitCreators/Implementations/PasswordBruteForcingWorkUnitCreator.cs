using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators.Implementations
{
    public class PasswordBruteForcingWorkUnitCreator : IWorkUnitCreator
    {
        public WorkUnit CreateWorkUnit(JobInstance jobInstance, Algorithm algorithm = null,
            ProgrammingLanguage programmingLanguage = null)
        {
            var workUnit = new WorkUnit
            {
                JobInstance = jobInstance,
                Algorithm = algorithm,
                ProgrammingLanguage = programmingLanguage
            };

            //TODO Implement some kind of mutex system so that one batch of data is given to one work unit
            //TODO Implement some kind of string split logic based on what last work unit had
            workUnit.DataIn = "aaa-ggg";

            return workUnit;
        }
    }
}