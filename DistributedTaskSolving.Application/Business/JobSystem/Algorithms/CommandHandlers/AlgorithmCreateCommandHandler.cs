using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandHandlers
{
    public class CreateAlgorithmCommand : IRequest<long>
    {
        public string Name { get; set; }
        public byte[] Code { get; set; }
        public Guid JobTypeId { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }

    public class AlgorithmCreateCommandHandler : IRequestHandler<CreateAlgorithmCommand, long>
    {
        private readonly IRepository<Algorithm, long> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<JobType, Guid> _jobTypeRepository;
        private readonly IRepository<ProgrammingLanguage, int> _programmingLanguageRepository;

        public AlgorithmCreateCommandHandler(IRepository<Algorithm, long> repository, 
            IMapper mapper, 
            IRepository<ProgrammingLanguage, int> programmingLanguageRepository, 
            IRepository<JobType, Guid> jobTypeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task<long> Handle(CreateAlgorithmCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Algorithm>(request);

            entity.JobType = await _jobTypeRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Id == request.JobTypeId, cancellationToken);

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
