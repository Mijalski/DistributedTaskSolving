using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.Profiles
{
    public class WorkUnitDtoToWorkUnitProfile : AutoMapper.Profile
    {
        public WorkUnitDtoToWorkUnitProfile()
        {
            CreateMap<WorkUnitDto, WorkUnit>()
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}