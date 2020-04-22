using DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandHandlers;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.Profiles
{
    public class AlgorithmProfiles : AutoMapper.Profile
    {
        public AlgorithmProfiles()
        {
            CreateMap<Algorithm, AlgorithmDto>();

            CreateMap<AlgorithmDto, CreateAlgorithmCommand>();

            CreateMap<AlgorithmDto, UpdateAlgorithmCommand>();

            CreateMap<CreateAlgorithmCommand, Algorithm>();

            CreateMap<UpdateAlgorithmCommand, Algorithm>();
        }
    }
}