using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators
{
    public interface IWorkUnitCreator
    {
        WorkUnit CreateWorkUnit(JobInstance jobInstance, Algorithm algorithm = null, ProgrammingLanguage programmingLanguage = null);
    }
}