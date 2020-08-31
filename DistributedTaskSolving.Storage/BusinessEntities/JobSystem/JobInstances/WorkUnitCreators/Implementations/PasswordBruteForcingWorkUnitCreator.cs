using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators.Implementations
{
    public class PasswordBruteForcingWorkUnitCreator : IWorkUnitCreator
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

            //TODO Implement some kind of mutex system so that one batch of data is given to one work unit
            //TODO Implement some kind of string split logic based on what last work unit had
            workUnit.DataIn = "aaa-ggg";

            return Task.FromResult(workUnit);
        }
    }
}