using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.CommandHandlers
{
    public class CreateJobTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class JobTypeCreateCommandHandler : IRequestHandler<CreateJobTypeCommand, Guid>
    {
        private readonly IRepository<JobType, Guid> _repository;
        private readonly IMapper _mapper;

        public JobTypeCreateCommandHandler(IRepository<JobType, Guid> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<JobType>(request);

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
