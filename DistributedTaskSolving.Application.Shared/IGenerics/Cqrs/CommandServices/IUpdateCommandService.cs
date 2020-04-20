using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;

namespace DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices
{
    public interface ICreateCommandService<TEntity, TPrimaryKey, TEntityDto, in TPrimaryKeyDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
    {
        Task<TEntityDto> Create(TEntityDto entityDto);
    }
}
