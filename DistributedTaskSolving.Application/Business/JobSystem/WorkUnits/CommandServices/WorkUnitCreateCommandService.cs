using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits.CommandServices
{
    public class WorkUnitCreateCommandService : CreateCommandService<WorkUnit, long, WorkUnitDto, long>
    {
        private readonly IRepository<JobInstance, long> _jobInstanceRepository;
        private readonly IRepository<JobType, Guid> _jobTypeRepository;
        public WorkUnitCreateCommandService(IRepository<WorkUnit, long> repository, 
            IValidator<WorkUnitDto> validator, IMapper mapper,
            IRepository<JobInstance, long> jobInstanceRepository, 
            IRepository<JobType, Guid> jobTypeRepository) 
            : base(repository, validator, mapper)
        {
            _jobInstanceRepository = jobInstanceRepository;
            _jobTypeRepository = jobTypeRepository;
        }

        public override async Task<WorkUnitDto> Create(WorkUnitDto input)
        {
            await ValidateAsync(input);

            var entity = _mapper.Map<WorkUnit>(input);

            if (input.JobInstanceId != 0)
            {
                entity.JobInstance = await _jobInstanceRepository.GetAsync(input.JobInstanceId);
            }
            else
            {
                var jobType = await _jobTypeRepository
                    .GetAll()
                    .Include(_ => _.Algorithms)
                    .ThenInclude(_ => _.JobType)
                    .SingleOrDefaultAsync(_ => _.Name == input.JobTypeName);

                var jobTypeQuery = _jobInstanceRepository
                    .GetAll()
                    .Where(_ => !_.IsSolved);

                if (jobType != null)
                {
                    jobTypeQuery = jobTypeQuery.Where(_ => _.Algorithm.JobType.Id == jobType.Id);
                }

                entity.JobInstance = await jobTypeQuery
                    .OrderBy(_ => _.CreationDateTime)
                    .FirstOrDefaultAsync();
            }

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<WorkUnitDto>(entity);
        }
    }
}