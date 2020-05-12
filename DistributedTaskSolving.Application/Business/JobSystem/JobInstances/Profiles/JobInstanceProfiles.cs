using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandHandlers;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Profiles
{
    public class JobInstanceProfiles : AutoMapper.Profile
    {
        public JobInstanceProfiles()
        {
            CreateMap<JobInstance, JobInstanceDto>()
                .ForMember(src => src.WorkUnitCount, opt => opt.MapFrom(dst => dst.WorkUnits.Count));

            CreateMap<JobInstanceDto, CreateJobInstanceCommand>();

            CreateMap<JobInstanceDto, UpdateJobInstanceCommand>();

            CreateMap<CreateJobInstanceCommand, JobInstance>();

            CreateMap<UpdateJobInstanceCommand, JobInstance>();
        }
    }
}