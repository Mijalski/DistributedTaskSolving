using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandHandlers
{
    public class CreateJobInstanceCommand : IRequest<long>
    {
        public string Key { get; set; }
        public string Result { get; set; }
        public long AlgorithmId { get; set; }
        public Guid JobTypeId { get; set; }
    }

    public class JobInstanceCreateCommandHandler : IRequestHandler<CreateJobInstanceCommand, long>
    {
        private readonly IRepository<JobInstance, long> _repository;
        private readonly IMapper _mapper;

        public JobInstanceCreateCommandHandler(IRepository<JobInstance, long> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateJobInstanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<JobInstance>(request);

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
