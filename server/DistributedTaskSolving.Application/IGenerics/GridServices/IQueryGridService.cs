using System.Collections.Generic;
using DistributedTaskSolving.Business.IGenerics.Entities;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.IGenerics.GridServices
{
    public interface IQueryGridService<TEntity, TPrimaryKey, TEntityDto>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IEnumerable<SelectItem> GetAllSelectItemList();
        ItemsDTO<TEntityDto> GetAll(QueryDictionary<StringValues> queryDictionary);
    }
}