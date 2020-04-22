using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.CommandHandlers
{
    public class UpdateProgrammingLanguageCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProgrammingLanguageUpdateCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, int>
    {
        private readonly IRepository<ProgrammingLanguage, int> _repository;
        private readonly IMapper _mapper;

        public ProgrammingLanguageUpdateCommandHandler(IRepository<ProgrammingLanguage, int> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
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
