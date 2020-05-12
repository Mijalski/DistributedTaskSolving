using System;
using DistributedTaskSolving.Application.Shared.Generics;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto
{
    public class JobInstanceDto : FullAuditedEntityDto<long>
    {
        public string Key { get; set; }
        public string Result { get; set; }
        public bool IsSolved { get; set; }
        public string JobTypeName { get; set; }
        public Guid JobTypeId { get; set; }
        public int WorkUnitCount { get; set; }
        public DateTime? FinishDateTime { get; set; }
    }
}