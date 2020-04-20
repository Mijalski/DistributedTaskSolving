using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;

namespace DistributedTaskSolving.Application.IGenerics.Endpoints
{
    public interface ICreateEndpoint<TEntity, TPrimaryKey, TCreateInput, in TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TCreateInput : class, IEntityDto<TPrimaryKeyDto>
    {
        Task<TCreateInput> Create(TCreateInput input);
    }
}