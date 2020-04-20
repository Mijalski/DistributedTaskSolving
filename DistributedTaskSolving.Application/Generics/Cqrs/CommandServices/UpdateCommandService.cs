using System;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using GridShared.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Generics.Cqrs.CommandServices
{
    public class UpdateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> : IUpdateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IValidator<TEntityDto> _validator;
        protected readonly IMapper _mapper;

        public UpdateCommandService(IRepository<TEntity, TPrimaryKey> repository, IValidator<TEntityDto> validator, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _mapper = mapper;
        }

        public async Task<TEntityDto> Update(TEntityDto entityDto, TPrimaryKeyDto updatedEntityId)
        {
            await ValidateAsync(entityDto);

            var entity = await _repository
                .GetAll()
                .Where("CoolId == @0", updatedEntityId)
                .SingleAsync();

            _mapper.Map(entityDto, entity);

            await AssignRelatedEntities(entity, entityDto);

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