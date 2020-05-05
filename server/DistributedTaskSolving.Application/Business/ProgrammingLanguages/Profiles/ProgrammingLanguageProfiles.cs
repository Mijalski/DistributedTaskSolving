using DistributedTaskSolving.Application.Business.ProgrammingLanguages.CommandHandlers;
using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.Profiles
{
    public class ProgrammingLanguageProfiles : AutoMapper.Profile
    {
        public ProgrammingLanguageProfiles()
        {
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>();
            CreateMap<ProgrammingLanguageDto, CreateProgrammingLanguageCommand>();

            CreateMap<ProgrammingLanguageDto, UpdateProgrammingLanguageCommand>();

            CreateMap<CreateProgrammingLanguageCommand, ProgrammingLanguage>();

            CreateMap<UpdateProgrammingLanguageCommand, ProgrammingLanguage>();
        }
    }
}