using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.IGenerics.Endpoints
{
    public interface ICrudEndpoint<TEntityDto, TPrimaryKeyDto, TGetRequest, in TUpdateRequest, in TCreateRequest, in TDeleteRequest>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
        where TGetRequest : IGetRequest<TPrimaryKeyDto>, IRequest<TEntityDto>
        where TDeleteRequest : IGetRequest<TPrimaryKeyDto>, IRequest
    {
    }
}