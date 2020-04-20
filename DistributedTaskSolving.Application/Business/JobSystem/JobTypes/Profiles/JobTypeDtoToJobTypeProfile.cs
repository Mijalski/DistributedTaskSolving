using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.Profiles
{
    public class JobTypeDtoToJobTypeProfile : AutoMapper.Profile
    {
        public JobTypeDtoToJobTypeProfile()
        {
            CreateMap<JobTypeDto, JobType>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}