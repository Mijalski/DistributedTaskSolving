using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Dto.Requests;
using DistributedTaskSolving.Application.Generics.Helpers;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.Generics.GridServices
{
    public class QueryGridService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> : IQueryGridService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        private readonly IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> _queryService;
        public QueryGridService(IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService)
        {
            _queryService = queryService;
        }

        public IEnumerable<SelectItem> GetAllSelectItemList()
        {
           return _queryService.GetAll()
               .Select(x => new SelectItem(x.Id.ToString(), x.Id.ToString()))
               .ToList();
        }

        public virtual ItemsDTO<TGetOutput> GetAll(QueryDictionary<StringValues> queryDictionary)
        {
            var query = _queryService.GetAll();

            var server = new GridServer<TGetOutput>(query, new QueryCollection(queryDictionary),
                true, "grid", pageSize: 10);

            return server.ItemsToDisplay;
        }
    }
}