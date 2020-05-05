using System.Threading.Tasks;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances
{
    public interface IJobInstanceHub
    {
        Task StartWorkOnJobType(string jobTypeName, string algorithmName, string programmingLanguageName);
        Task FinishWorkUnit(long workUnitId, string dataOut, bool isSolved);
    }
}