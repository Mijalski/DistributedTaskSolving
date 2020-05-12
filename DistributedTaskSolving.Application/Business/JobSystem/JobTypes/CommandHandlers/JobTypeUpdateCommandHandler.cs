using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.CommandHandlers
{
    public class UpdateJobTypeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class JobTypeUpdateCommandHandler : IRequestHandler<UpdateJobTypeCommand, Guid>
    {
        private readonly IRepository<JobType, Guid> _repository;
        private readonly IMapper _mapper;

        public JobTypeUpdateCommandHandler(IRepository<JobType, Guid> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateJobTypeCommand request, CancellationToken cancellationToken)
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
