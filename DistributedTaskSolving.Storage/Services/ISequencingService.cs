using System.Collections.Generic;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Business.Services
{
    public interface ISequencingService
    {
        void AddOrUpdateWorkUnit(WorkUnit unit);
        Task<JobInstance> GetJobInstanceAsync(long id);
        IEnumerable<string> GetSolvedVertices();
        IEnumerable<string> GetUsedVertices();
        void RemoveWorkUnit(string dataIn);
    }
}