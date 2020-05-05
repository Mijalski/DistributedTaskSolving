using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.QueryHandlers
{
    public class AlgorithmQuery : IRequest<AlgorithmDto>, IGetRequest<long>
    {
        public long Id { get; set; }
    }

    public class AlgorithmQueryHandler : IRequestHandler<AlgorithmQuery, AlgorithmDto>
    {
        private readonly IRepository<Algorithm, long> _repository;
        private readonly IMapper _mapper;

        public AlgorithmQueryHandler(IRepository<Algorithm, long> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AlgorithmDto> Handle(AlgorithmQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .Include(_ => _.JobType)
                .AsNoTracking()
                .ProjectTo<AlgorithmDto>(_mapper.ConfigurationProvider);

            return await query.SingleOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
        }
    }
}
