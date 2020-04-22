using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.CommandHandlers
{
    public class CreateProgrammingLanguageCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class ProgrammingLanguageCreateCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, int>
    {
        private readonly IRepository<ProgrammingLanguage, int> _repository;
        private readonly IMapper _mapper;

        public ProgrammingLanguageCreateCommandHandler(IRepository<ProgrammingLanguage, int> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProgrammingLanguage>(request);

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
