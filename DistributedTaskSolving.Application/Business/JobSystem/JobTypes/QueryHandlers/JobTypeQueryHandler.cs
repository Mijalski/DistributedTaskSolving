using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes.QueryHandlers
{
    public class JobTypeQuery : IRequest<JobTypeDto>, IGetRequest<Guid>
    {
        public Guid Id { get; set; }
    }

    public class JobTypeQueryHandler : IRequestHandler<JobTypeQuery, JobTypeDto>
    {
        private readonly IRepository<JobType, Guid> _repository;
        private readonly IMapper _mapper;

        public JobTypeQueryHandler(IRepository<JobType, Guid> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<JobTypeDto> Handle(JobTypeQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .Include(_ => _.Algorithms)
                .AsNoTracking()
                .ProjectTo<JobTypeDto>(_mapper.ConfigurationProvider);

            return await query.SingleOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
        }
    }
}
