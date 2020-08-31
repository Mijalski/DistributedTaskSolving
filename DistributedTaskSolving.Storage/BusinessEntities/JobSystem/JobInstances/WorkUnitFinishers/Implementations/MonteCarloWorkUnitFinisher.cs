using System;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitFinishers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers.Implementations
{
    public class MonteCarloWorkUnitFinisher : IWorkUnitFinisher
    {
        public void FinishAbandonedWorkUnit(WorkUnit workUnit)
        {

        }

        public void FinishJobInstance(JobInstance jobInstance)
        {

        }

        public Task<bool> FinishWorkUnitAsync(WorkUnit workUnit, string dataOut, bool isSolved)
        {
            workUnit.IsSolved = isSolved;
            workUnit.DataOut = dataOut;
            workUnit.SubmitDateTime = DateTime.UtcNow;

            if (isSolved)
            {
                workUnit.JobInstance.IsSolved = true;
                workUnit.JobInstance.Result = dataOut;
            }

            return Task.FromResult(isSolved);
        }
    }
}