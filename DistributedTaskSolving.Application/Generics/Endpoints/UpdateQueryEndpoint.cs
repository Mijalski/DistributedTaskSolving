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
    public class UpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto>
        : UpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TGetOutput>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        public UpdateQueryEndpoint(IUpdateCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> updateCommandService,
            IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService)
            : base(updateCommandService, queryService)
        {
        }
    }

    [EndpointNameConvention]
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TUpdateInput>
        : QueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto>, IUpdateEndpoint<TEntity, TPrimaryKey, TUpdateInput, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
        where TUpdateInput : class, IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IUpdateCommandService<TEntity, TPrimaryKey, TUpdateInput, TPrimaryKeyDto> _updateCommandService;

        public UpdateQueryEndpoint(
            IUpdateCommandService<TEntity, TPrimaryKey, TUpdateInput, TPrimaryKeyDto> updateCommandService,
            IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService
        )
            : base(queryService)
        {
            _updateCommandService = updateCommandService;
        }

        [HttpPost("{id}")]
        public virtual async Task<TUpdateInput> Update([FromBody] TUpdateInput input, TPrimaryKeyDto id)
        {
            return await _updateCommandService.Update(input, id);
        }
    }
}
