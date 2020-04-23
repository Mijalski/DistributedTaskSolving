using System.Threading;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.CommandHandlers
{
    public class DeleteProgrammingLanguageCommand : IRequest, IGetRequest<int>
    {
        public int Id { get; set; }
    }

    public class ProgrammingLanguageDeleteCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand>
    {
        private readonly IRepository<ProgrammingLanguage, int> _repository;

        public ProgrammingLanguageDeleteCommandHandler(IRepository<ProgrammingLanguage, int> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
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
