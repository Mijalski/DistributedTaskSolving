using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using GridShared;

namespace DistributedTaskSolving.Application.IGenerics.GridServices
{
    public interface ICrudGridService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> : ICrudDataService<TEntityDto>
        where TEntityDto : class, IEntityDto<TPrimaryKeyDto>
    {
        Task<TEntityDto> Get(params object[] keys);
        Task Insert(TEntityDto item);
        Task Update(TEntityDto item);
        Task Delete(params object[] keys);
    }
}