using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandHandlers
{
    public class DeleteJobInstanceCommand : IRequest, IGetRequest<long>
    {
        public long Id { get; set; }
    }

    public class JobInstanceDeleteCommandHandler : IRequestHandler<DeleteJobInstanceCommand>
    {
        private readonly IRepository<JobInstance, long> _repository;

        public JobInstanceDeleteCommandHandler(IRepository<JobInstance, long> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteJobInstanceCommand request, CancellationToken cancellationToken)
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
