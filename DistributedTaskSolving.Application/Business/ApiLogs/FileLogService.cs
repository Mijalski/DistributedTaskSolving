using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace DistributedTaskSolving.Application.Business.ApiLogs
{
    public class FileLogService : IFileLogService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileLogService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> GetFileLogs()
        {
            var logFilePath = $"{_webHostEnvironment.ContentRootPath}/App_Data/Logs/Logs.log";
            var fileContent = await File.ReadAllTextAsync(logFilePath);

            return fileContent;
        }
    }
}