using System;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitFinishers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers.Implementations
{
    public class PasswordBruteForcingWorkUnitFinisher : IWorkUnitFinisher
    {
        public void FinishWorkUnit(WorkUnit workUnit, string dataOut, bool isSolved)
        {
            workUnit.IsSolved = isSolved;
            workUnit.DataOut = dataOut;
            workUnit.SubmitDateTime = DateTime.UtcNow;

            if (isSolved)
            {
                workUnit.JobInstance.IsSolved = true;
                workUnit.JobInstance.Result = dataOut;
            }
        }
    }
}