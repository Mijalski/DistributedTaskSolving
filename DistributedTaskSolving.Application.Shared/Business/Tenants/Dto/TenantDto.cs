using DistributedTaskSolving.Application.Shared.Generics;
using DistributedTaskSolving.Application.Shared.Generics.Dto;

namespace DistributedTaskSolving.Application.Shared.Business.Tenants.Dto
{
    public class TenantDto : FullAuditedEntityDto<string>
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}