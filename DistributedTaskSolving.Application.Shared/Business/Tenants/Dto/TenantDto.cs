using DistributedTaskSolving.Application.Shared.Generics;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.Tenants.Dto
{
    public class TenantDto : FullAuditedEntityDto<long>
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}