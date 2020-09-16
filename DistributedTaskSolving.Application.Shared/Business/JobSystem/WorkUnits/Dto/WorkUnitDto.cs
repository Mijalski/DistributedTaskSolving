using System;
using DistributedTaskSolving.Application.Shared.Generics;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto
{
    public class WorkUnitDto : CreationAuditedEntityDto<long>
    {
        public long JobInstanceId { get; set; }
        public string JobTypeName { get; set; }
        public string DataIn { get; set; }
        public string DataOut { get; set; }
        public bool IsAbandoned { get; set; }
        public bool IsSolved { get; set; }
        public DateTime? SubmitDateTime { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public string AlgorithmName { get; set; }
        public string UserAgent { get; set; }
        public string RamSize { get; set; }
        public string ConnectionId { get; set; }
        public double ExecutionTimeInMs { get; set; }
    }
}