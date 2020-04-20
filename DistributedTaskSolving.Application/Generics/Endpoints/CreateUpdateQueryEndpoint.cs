using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.MatchingStrategies;
using DistributedTaskSolving.Application.IGenerics.Endpoints;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DistributedTaskSolving.Application.Generics.Endpoints
{
    public class CreateUpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> :
        CreateUpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TGetOutput, TGetOutput>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        public CreateUpdateQueryEndpoint(ICreateCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> createCommandService,
            IUpdateCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> updateCommandService,
            IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService)
            : base(createCommandService, updateCommandService, queryService)
        {
        }
    }

    [EndpointNameConvention]
    [ApiController]
    [Route("api/[controller]")]
    public class CreateUpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TUpdateInput, TCreateInput>
        : UpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TUpdateInput>, ICreateEndpoint<TEntity, TPrimaryKey, TCreateInput, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
        where TUpdateInput : class, IEntityDto<TPrimaryKeyDto>
        where TCreateInput : class, IEntityDto<TPrimaryKeyDto>
    {
        protected readonly ICreateCommandService<TEntity, TPrimaryKey, TCreateInput, TPrimaryKeyDto> _createCommandService;

        public CreateUpdateQueryEndpoint(
            ICreateCommandService<TEntity, TPrimaryKey, TCreateInput, TPrimaryKeyDto> createCommandService,
            IUpdateCommandService<TEntity, TPrimaryKey, TUpdateInput, TPrimaryKeyDto> updateCommandService,
            IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService
        )
            : base(updateCommandService, queryService)
        {
            _createCommandService = createCommandService;
        }

        [HttpPut]
        public virtual async Task<TCreateInput> Create([FromBody] TCreateInput input)
        {
            return await _createCommandService.Create(input);
        }

    }
}
