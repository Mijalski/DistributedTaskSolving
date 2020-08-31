using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances
{
    public interface IJobInstanceHub
    {
        Task StartWorkOnJobType(string jobTypeName, WorkUnitClientDto workUnitClientDto,
            string algorithmName, string programmingLanguageName);
        Task FinishWorkUnit(long workUnitId, string data, bool isSolved, string jobTypeName);
    }
}