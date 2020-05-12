using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.QueryHandlers;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.QueryHandlers
{
    public class WorkUnitForJobInstanceQuery : IRequest<List<WorkUnitDto>>, IGetRequest<long>
    {
        public long Id { get; set; }
    }

    public class WorkUnitForJobInstanceQueryHandler : IRequestHandler<WorkUnitForJobInstanceQuery, List<WorkUnitDto>>
    {
        private readonly IRepository<WorkUnit, long> _repository;
        private readonly IMapper _mapper;

        public WorkUnitForJobInstanceQueryHandler(IRepository<WorkUnit, long> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WorkUnitDto>> Handle(WorkUnitForJobInstanceQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .AsNoTracking()
                .Include(_ => _.Algorithm)
                .Include(_ => _.ProgrammingLanguage)
                .Where(_ => _.JobInstanceId == request.Id)
                .ProjectTo<WorkUnitDto>(_mapper.ConfigurationProvider);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
