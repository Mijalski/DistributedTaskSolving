using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.Profiles
{
    public class WorkUnitProfiles : AutoMapper.Profile
    {
        public WorkUnitProfiles()
        {
            CreateMap<WorkUnit, WorkUnitDto>()
                .ForMember(src => src.UserAgent, opt => opt.MapFrom(dst => dst.WorkUnitClient.UserAgent))
                .ForMember(src => src.RamSize, opt => opt.MapFrom(dst => dst.WorkUnitClient.RamSize))
                .ForMember(src => src.JobTypeName, opt => opt.MapFrom(dst => dst.JobInstance.JobType.Name));
        }
    }
}