using DistributedTaskSolving.Application.Shared.Business.Tenants.Dto;
using DistributedTaskSolving.Business.BusinessEntities.Tenants;

namespace DistributedTaskSolving.Application.Business.Tenants.Profiles
{
    public class TenantToTenantDtoProfile : AutoMapper.Profile
    {
        public TenantToTenantDtoProfile()
        {
            CreateMap<Tenant, TenantDto>();
        }
    }
}