using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators
{
    public interface IWorkUnitCreator
    {
        Task<WorkUnit> CreateWorkUnitAsync(long jobInstanceId, Algorithm algorithm = null, ProgrammingLanguage programmingLanguage = null);
    }
}