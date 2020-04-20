using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.Profiles
{
    public class ProgrammingLanguageDtoToProgrammingLanguageProfile : AutoMapper.Profile
    {
        public ProgrammingLanguageDtoToProgrammingLanguageProfile()
        {
            CreateMap<ProgrammingLanguageDto, ProgrammingLanguage>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Id))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}