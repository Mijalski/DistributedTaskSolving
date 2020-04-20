
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Profiles
{
    public class JobInstanceDtoToJobInstanceProfile : AutoMapper.Profile
    {
        public JobInstanceDtoToJobInstanceProfile()
        {
            CreateMap<JobInstanceDto, JobInstance>()
                .ForMember(dst => dst.Key, opt => opt.MapFrom(src => src.Key))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}