using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.Profiles
{
    public class WorkUnitToWorkUnitDtoProfile : AutoMapper.Profile
    {
        public WorkUnitToWorkUnitDtoProfile()
        {
            CreateMap<WorkUnit, WorkUnitDto>()
                .ForMember(dst => dst.JobInstanceId, opt => opt.MapFrom(src => src.JobInstance.Id))
                .ForMember(dst => dst.JobTypeName, opt => opt.MapFrom(src => src.JobInstance.Algorithm.JobType.Name));
        }
    }
}