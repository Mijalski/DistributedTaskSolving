using System;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices
{
    public interface IQueryService<TEntity, TPrimaryKey, TEntityDto, in TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        Task<TEntityDto> Get(TPrimaryKeyDto primaryKeyDto);
        IQueryable<TEntityDto> GetAll();
    }
}