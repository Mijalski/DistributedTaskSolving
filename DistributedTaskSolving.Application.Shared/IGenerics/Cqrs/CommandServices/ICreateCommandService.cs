using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;

namespace DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices
{
    public interface IUpdateCommandService<TEntity, TPrimaryKey, TEntityDto, in TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        Task<TEntityDto> Update(TEntityDto entityDto, TPrimaryKeyDto updatedEntityId);
    }
}
