using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Dto.Results;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;

namespace DistributedTaskSolving.Application.IGenerics.Endpoints
{
    public interface IQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, in TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        Task<TGetOutput> Get(TPrimaryKeyDto id);
        Task<PagedResultDto<TGetOutput>> GetAll(string sorting = null, int maxResultCount = 10, int skipCount = 0);
    }
}