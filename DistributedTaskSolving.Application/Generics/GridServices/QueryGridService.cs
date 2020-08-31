using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics.Entities;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.Generics.GridServices
{
    public class QueryGridService<TEntity, TPrimaryKey, TEntityDto> : IQueryGridService<TEntity, TPrimaryKey, TEntityDto>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IMapper _mapper;

        public QueryGridService(IRepository<TEntity, TPrimaryKey> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual IEnumerable<SelectItem> GetAllSelectItemList()
        {
           return _repository.GetAll()
               .Select(x => new SelectItem(x.Id.ToString(), x.Id.ToString()))
               .ToList();
        }

        public virtual ItemsDTO<TEntityDto> GetAll(QueryDictionary<StringValues> queryDictionary)
        {
            var query = _repository.GetAll()
                .ProjectTo<TEntityDto>(_mapper.ConfigurationProvider);

            var server = new GridServer<TEntityDto>(query, new QueryCollection(queryDictionary),
                true, "grid", pageSize: 10);

            return server.ItemsToDisplay;
        }
    }
}