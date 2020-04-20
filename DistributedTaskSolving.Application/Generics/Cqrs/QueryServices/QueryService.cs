using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.Generics.Cqrs.QueryServices
{
    public class QueryService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> : IQueryService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IMapper _mapper;

        public QueryService(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<TEntityDto> Get(TPrimaryKeyDto input)
        {
            return await ConfigureIncludes()
                .AsNoTracking()
                .ProjectTo<TEntityDto>(_mapper.ConfigurationProvider)
                .Where("Id == @0", input)
                .FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntityDto> GetAll()
        {
            return ConfigureIncludes()
                .AsNoTracking()
                .ProjectTo<TEntityDto>(_mapper.ConfigurationProvider);
        }

        protected virtual IQueryable<TEntity> ConfigureIncludes()
        {
            return _repository
                .GetAll();
        }
    }
}