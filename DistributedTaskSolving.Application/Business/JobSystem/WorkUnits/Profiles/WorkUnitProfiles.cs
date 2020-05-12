using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.Profiles
{
    public class WorkUnitProfiles : AutoMapper.Profile
    {
        public WorkUnitProfiles()
        {
            CreateMap<WorkUnit, WorkUnitDto>()
                .ForMember(src => src.JobTypeName, opt => opt.MapFrom(dst => dst.JobInstance.JobType.Name));
        }
    }
}