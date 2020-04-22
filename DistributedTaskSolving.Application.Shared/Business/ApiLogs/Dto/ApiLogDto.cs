using System;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.ApiLogs.Dto
{
    public class ApiLogDto : CreationAuditedEntityDto<long>
    {
        public DateTime RequestTime { get; set; }
        public long ResponseMillis { get; set; }
        public int StatusCode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string IpAddress { get; set; }
    }
}