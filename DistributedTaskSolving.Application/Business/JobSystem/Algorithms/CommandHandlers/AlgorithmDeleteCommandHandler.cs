using System.Threading;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandHandlers
{
    public class DeleteAlgorithmCommand : IRequest, IGetRequest<long>
    {
        public long Id { get; set; }
    }

    public class AlgorithmDeleteCommandHandler : IRequestHandler<DeleteAlgorithmCommand>
    {
        private readonly IRepository<Algorithm, long> _repository;

        public AlgorithmDeleteCommandHandler(IRepository<Algorithm, long> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAlgorithmCommand request, CancellationToken cancellationToken)
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
