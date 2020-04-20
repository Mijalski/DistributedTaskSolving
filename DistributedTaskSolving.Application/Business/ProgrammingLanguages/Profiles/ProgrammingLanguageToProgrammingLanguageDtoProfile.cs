using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.Profiles
{
    public class ProgrammingLanguageToProgrammingLanguageDtoProfile : AutoMapper.Profile
    {
        public ProgrammingLanguageToProgrammingLanguageDtoProfile()
        {
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Name));
        }
    }
}