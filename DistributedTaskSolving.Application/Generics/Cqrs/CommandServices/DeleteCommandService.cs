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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Generics.Cqrs.CommandServices
{
    public class DeleteCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> : IDeleteCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IValidator<TEntityDto> _validator;
        protected readonly IMapper _mapper;

        public DeleteCommandService(IRepository<TEntity, TPrimaryKey> repository, IValidator<TEntityDto> validator, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _mapper = mapper;
        }

        public async Task Delete(TPrimaryKeyDto deletedEntityId)
        {
            var entity = await _repository
                .GetAll()
                .Where("Name == @0", deletedEntityId)
                .SingleAsync();

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}