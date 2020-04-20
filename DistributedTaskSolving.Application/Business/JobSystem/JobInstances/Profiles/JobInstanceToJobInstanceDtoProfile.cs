using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Profiles
{
    public class JobInstanceToJobInstanceDtoProfile : AutoMapper.Profile
    {
        public JobInstanceToJobInstanceDtoProfile()
        {
            CreateMap<JobInstance, JobInstanceDto>()
                .ForMember(dst => dst.JobTypeName, opt => opt.MapFrom(src => src.Algorithm.JobType.Name))
                .ForMember(dst => dst.AlgorithmName, opt => opt.MapFrom(src => src.Algorithm.Name))
                .ForMember(dst => dst.AlgorithmCode, opt => opt.MapFrom(src => src.Algorithm.Code));
        }
    }
}