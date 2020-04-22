using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Generics.MatchingStrategies;
using DistributedTaskSolving.Application.Generics.Requests;
using DistributedTaskSolving.Application.IGenerics.Endpoints;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DistributedTaskSolving.Application.Generics.Endpoints
{
    [ApiController]
    [EndpointNameConvention]
    [Route("api/[controller]")]
    public class CrudEndpoint<TEntityDto, TPrimaryKeyDto, TGetRequest, TUpdateRequest, TCreateRequest, TDeleteRequest>
        : ICrudEndpoint<TEntityDto, TPrimaryKeyDto, TGetRequest, TUpdateRequest, TCreateRequest, TDeleteRequest>
        where TEntityDto : IEntityDto<TPrimaryKeyDto>
        where TGetRequest : IGetRequest<TPrimaryKeyDto>, IRequest<TEntityDto>
        where TDeleteRequest : IGetRequest<TPrimaryKeyDto>, IRequest
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CrudEndpoint(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<TEntityDto> Get(TGetRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public virtual async Task Insert(TEntityDto item)
        {
            var request = _mapper.Map<TCreateRequest>(item);
            await _mediator.Send(request);
        }

        [HttpPut]
        public virtual async Task Update(TEntityDto item)
        {
            var request = _mapper.Map<TUpdateRequest>(item);
            await _mediator.Send(request);
        }

        [HttpDelete]
        public virtual async Task Delete(TDeleteRequest request)
        {
            await _mediator.Send(request);
        }
    }
}