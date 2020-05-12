using System.Linq;
using DistributedTaskSolving.Application.Business.JobSystem.JobTypes.CommandHandlers;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.Profiles
{
    public class JobTypeProfiles : AutoMapper.Profile
    {
        public JobTypeProfiles()
        {
            CreateMap<JobType, JobTypeDto>();

            CreateMap<JobTypeDto, CreateJobTypeCommand>();

            CreateMap<JobTypeDto, UpdateJobTypeCommand>();

            CreateMap<CreateJobTypeCommand, JobType>();

            CreateMap<UpdateJobTypeCommand, JobType>();
        }
    }
}