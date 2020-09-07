using System;
using DistributedTaskSolving.Business.Generics.Entities;
using DistributedTaskSolving.Business.IGenerics;

namespace DistributedTaskSolving.Business.BusinessEntities.ApiLogs
{
    public class ApiLog : CreationAuditedEntity
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