using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using GridShared;
using MediatR;

namespace DistributedTaskSolving.Application.IGenerics.GridServices
{
    public interface ICrudGridService<TEntityDto, TPrimaryKeyDto, TGetRequest, in TUpdateRequest, in TCreateRequest, in TDeleteRequest> : ICrudDataService<TEntityDto>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
        where TGetRequest : IGetRequest<TPrimaryKeyDto>, IRequest<TEntityDto>, new()
        where TDeleteRequest : IGetRequest<TPrimaryKeyDto>, IRequest, new()
    {
    }
}