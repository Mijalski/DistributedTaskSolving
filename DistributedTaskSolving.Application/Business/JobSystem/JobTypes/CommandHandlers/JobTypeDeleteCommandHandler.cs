using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.CommandHandlers
{
    public class DeleteJobTypeCommand : IRequest, IGetRequest<Guid>
    {
        public Guid Id { get; set; }
    }

    public class JobTypeDeleteCommandHandler : IRequestHandler<DeleteJobTypeCommand>
    {
        private readonly IRepository<JobType, Guid> _repository;
        private readonly IMapper _mapper;

        public JobTypeDeleteCommandHandler(IRepository<JobType, Guid> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteJobTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository
                .GetAll()
                .SingleAsync(_ => _.Id == request.Id, cancellationToken);

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
