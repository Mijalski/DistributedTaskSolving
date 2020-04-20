using System;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using GridShared.Utility;

namespace DistributedTaskSolving.Application.Generics.Cqrs.CommandServices
{
    public class CreateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> : ICreateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IValidator<TEntityDto> _validator;
        protected readonly IMapper _mapper;

        public CreateCommandService(IRepository<TEntity, TPrimaryKey> repository, IValidator<TEntityDto> validator, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _mapper = mapper;
        }

        public virtual async Task<TEntityDto> Create(TEntityDto input)
        {
            await ValidateAsync(input);

            var entity = _mapper.Map<TEntity>(input);

            await AssignRelatedEntities(entity, input);

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TEntityDto>(entity);
        }

        protected async Task<bool> ValidateAsync(TEntityDto input)
        {
            var validationResult = await _validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                throw new GridException("Object is not valid.");
            }

            return validationResult.IsValid;
        }

        protected virtual async Task AssignRelatedEntities(TEntity entity, TEntityDto input)
        {

        }
    }
}