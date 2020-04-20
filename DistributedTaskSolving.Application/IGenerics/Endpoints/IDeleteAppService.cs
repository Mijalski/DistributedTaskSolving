using System.Threading.Tasks;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;

namespace DistributedTaskSolving.Application.IGenerics.Endpoints
{
    public interface IDeleteEndpoint<TEntity, TPrimaryKey, in TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
    {
        Task Delete(TPrimaryKeyDto id);
    }
}