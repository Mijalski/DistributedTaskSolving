using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitFinishers;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers
{
    public delegate IWorkUnitFinisher WorkUnitFinisherServiceResolver(string jobTypeName);
}