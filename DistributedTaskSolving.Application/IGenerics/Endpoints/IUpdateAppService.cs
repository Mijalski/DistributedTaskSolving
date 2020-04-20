using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;

namespace DistributedTaskSolving.Application.IGenerics.Endpoints
{
    public interface IUpdateEndpoint<TEntity, TPrimaryKey, TUpdateInput, in TPrimaryKeyDto> 
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TUpdateInput : class, IEntityDto<TPrimaryKeyDto>
    {
        Task<TUpdateInput> Update(TUpdateInput input, TPrimaryKeyDto id);
    }
}