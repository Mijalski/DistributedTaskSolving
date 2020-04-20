using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;

namespace DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices
{
    public interface IDeleteCommandService<TEntity, TPrimaryKey, TEntityDto, in TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        Task Delete(TPrimaryKeyDto deletedEntityId);
    }
}
