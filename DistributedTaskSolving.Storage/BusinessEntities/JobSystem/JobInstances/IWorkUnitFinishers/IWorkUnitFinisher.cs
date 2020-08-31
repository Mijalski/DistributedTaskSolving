using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitFinishers
{
    public interface IWorkUnitFinisher
    {
        Task<bool> FinishWorkUnitAsync(WorkUnit workUnit, string dataOut, bool isSolved);
        void FinishJobInstance(JobInstance jobInstance);
        void FinishAbandonedWorkUnit(WorkUnit workUnit);
    }
}