using System.Collections.Generic;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.IGenerics.GridServices
{
    public interface IQueryGridService<TEntity, TPrimaryKey, TGetOutput, in TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        IEnumerable<SelectItem> GetAllSelectItemList();
        ItemsDTO<TGetOutput> GetAll(QueryDictionary<StringValues> queryDictionary);
    }
}