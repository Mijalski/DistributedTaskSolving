using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators
{
    public delegate IWorkUnitCreator WorkUnitCreatorServiceResolver(string jobTypeName);
}