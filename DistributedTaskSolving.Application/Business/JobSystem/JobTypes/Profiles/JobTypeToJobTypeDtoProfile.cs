using System.Linq;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.Profiles
{
    public class JobTypeToJobTypeDtoProfile : AutoMapper.Profile
    {
        public JobTypeToJobTypeDtoProfile()
        {
            CreateMap<JobType, JobTypeDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Name));
        }
    }
}