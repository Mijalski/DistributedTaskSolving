using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.Profiles
{
    public class AlgorithmDtoToAlgorithmProfile : AutoMapper.Profile
    {
        public AlgorithmDtoToAlgorithmProfile()
        {
            CreateMap<AlgorithmDto, Algorithm>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Id))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}