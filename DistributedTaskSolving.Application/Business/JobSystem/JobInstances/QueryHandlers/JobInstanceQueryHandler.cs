using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.QueryHandlers
{
    public class JobInstanceQuery : IRequest<JobInstanceDto>, IGetRequest<long>
    {
        public long Id { get; set; }
    }

    public class JobInstanceQueryHandler : IRequestHandler<JobInstanceQuery, JobInstanceDto>
    {
        private readonly IRepository<JobInstance, long> _repository;
        private readonly IMapper _mapper;

        public JobInstanceQueryHandler(IRepository<JobInstance, long> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<JobInstanceDto> Handle(JobInstanceQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .AsNoTracking()
                .ProjectTo<JobInstanceDto>(_mapper.ConfigurationProvider);

            return await query.SingleOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
        }
    }
}
