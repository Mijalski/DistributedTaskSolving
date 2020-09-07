using System.Threading.Tasks;

namespace DistributedTaskSolving.Application.Business.ApiLogs
{
    public interface IFileLogService
    {
        Task<string> GetFileLogs();
    }
}