using System;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.ApiLogs.Dto
{
    public class ApiLogDto : CreationAuditedEntityDto<long>
    {
        public string Level { get; set; }
        public string Logger { get; set; }
        public string TraceIdentifier { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUrl { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseBody { get; set; }
    }
}