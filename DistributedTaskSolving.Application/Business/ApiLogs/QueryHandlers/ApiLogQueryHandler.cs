using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.Business.ApiLogs.Dto;
using DistributedTaskSolving.Business.BusinessEntities.ApiLogs;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.ApiLogs.QueryHandlers
{
    public class ApiLogQuery : IRequest<ApiLogDto>, IGetRequest<long>
    {
        public long Id { get; set; }
    }

    public class ApiLogQueryHandler : IRequestHandler<ApiLogQuery, ApiLogDto>
    {
        private readonly IRepository<ApiLog, long> _repository;
        private readonly IMapper _mapper;

        public ApiLogQueryHandler(IRepository<ApiLog, long> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiLogDto> Handle(ApiLogQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .AsNoTracking()
                .ProjectTo<ApiLogDto>(_mapper.ConfigurationProvider);

            return await query.SingleOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
        }
    }
}
