using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitFinishers
{
    public interface IWorkUnitFinisher
    {
        void FinishWorkUnit(WorkUnit workUnit, string dataOut, bool isSolved);
    }
}