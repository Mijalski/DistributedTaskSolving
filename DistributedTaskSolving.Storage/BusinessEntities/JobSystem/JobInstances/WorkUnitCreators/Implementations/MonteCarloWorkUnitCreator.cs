using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators.Implementations
{
    public class MonteCarloWorkUnitCreator : IWorkUnitCreator
    {
        public Task<WorkUnit> CreateWorkUnitAsync(long jobInstanceId, Algorithm algorithm = null,
            ProgrammingLanguage programmingLanguage = null)
        {
            var workUnit = new WorkUnit
            {
                JobInstanceId = jobInstanceId,
                Algorithm = algorithm,
                ProgrammingLanguage = programmingLanguage
            };

            workUnit.DataIn = "1000"; // every client will make 1000 calculations

            return Task.FromResult(workUnit);
        }
    }
}