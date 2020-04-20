using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.Profiles
{
    public class AlgorithmToAlgorithmDtoProfile : AutoMapper.Profile
    {
        public AlgorithmToAlgorithmDtoProfile()
        {
            CreateMap<Algorithm, AlgorithmDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.ProgrammingLanguageName, opt => opt.MapFrom(src => src.ProgrammingLanguage.Name))
                .ForMember(dst => dst.JobTypeName, opt => opt.MapFrom(src => src.JobType.Name));
        }
    }
}