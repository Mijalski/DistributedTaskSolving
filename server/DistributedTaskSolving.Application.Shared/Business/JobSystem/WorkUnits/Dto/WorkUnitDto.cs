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
    }
}