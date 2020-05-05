using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Generics.GridServices
{
    public class CrudGridService<TEntityDto, TPrimaryKeyDto, TGetRequest, TUpdateRequest, TCreateRequest, TDeleteRequest> 
        : ICrudGridService<TEntityDto, TPrimaryKeyDto, TGetRequest, TUpdateRequest, TCreateRequest, TDeleteRequest>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
        where TGetRequest : IGetRequest<TPrimaryKeyDto>, IRequest<TEntityDto>, new()
        where TDeleteRequest : IGetRequest<TPrimaryKeyDto>, IRequest, new()
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CrudGridService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TEntityDto> Get(params object[] keys)
        {
            var id = (TPrimaryKeyDto)keys[0];
            var newRequest = new TGetRequest { Id = id };
            return await _mediator.Send(newRequest);
        }

        public async Task Insert(TEntityDto item)
        {
            var request = _mapper.Map<TCreateRequest>(item);
            await _mediator.Send(request);
        }

        public async Task Update(TEntityDto item)
        {
            var request = _mapper.Map<TUpdateRequest>(item);
            await _mediator.Send(request);
        }
        
        public async Task Delete(params object[] keys)
        {
            var id = (TPrimaryKeyDto)keys[0];
            var newRequest = new TDeleteRequest { Id = id };
            await _mediator.Send(newRequest);
        }
    }
}