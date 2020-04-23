using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandHandlers
{
    public class UpdateJobInstanceCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Result { get; set; }
        public long AlgorithmId { get; set; }
        public Guid JobTypeId { get; set; }
    }

    public class JobInstanceUpdateCommandHandler : IRequestHandler<UpdateJobInstanceCommand, long>
    {
        private readonly IRepository<JobInstance, long> _repository;
        private readonly IMapper _mapper;

        public JobInstanceUpdateCommandHandler(IRepository<JobInstance, long> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> Handle(UpdateJobInstanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository
                .GetAll()
                .SingleAsync(_ => _.Id == request.Id, cancellationToken);

            entity = _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
