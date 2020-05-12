using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators.Implementations
{
    public class MonteCarloWorkUnitCreator : IWorkUnitCreator
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

            workUnit.DataIn = "1000"; // every client will make 1000 calculations

            return workUnit;
        }
    }
}