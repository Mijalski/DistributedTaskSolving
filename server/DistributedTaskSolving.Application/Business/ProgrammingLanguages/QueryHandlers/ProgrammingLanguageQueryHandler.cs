using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.ProgrammingLanguages.QueryHandlers
{
    public class ProgrammingLanguageQuery : IGetRequest<int>, IRequest<ProgrammingLanguageDto>
    {
        public int Id { get; set; }
    }

    public class ProgrammingLanguageQueryHandler : IRequestHandler<ProgrammingLanguageQuery, ProgrammingLanguageDto>
    {
        private readonly IRepository<ProgrammingLanguage, int> _repository;
        private readonly IMapper _mapper;

        public ProgrammingLanguageQueryHandler(IRepository<ProgrammingLanguage, int> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageDto> Handle(ProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .AsNoTracking()
                .ProjectTo<ProgrammingLanguageDto>(_mapper.ConfigurationProvider);

            return await query.SingleOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
        }
    }
}
