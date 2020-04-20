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
    public class CrudEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> :
        CrudEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TGetOutput, TGetOutput>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        public CrudEndpoint(IDeleteCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> deleteCommandService,
            ICreateCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> createCommandService,
            IUpdateCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> updateCommandService,
            IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService)
            : base(deleteCommandService, createCommandService, updateCommandService, queryService)
        {
        }
    }

    [EndpointNameConvention]
    [ApiController]
    [Route("api/[controller]")]
    public class CrudEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TUpdateInput, TCreateInput> :
        CreateUpdateQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto, TUpdateInput, TCreateInput>, IDeleteEndpoint<TEntity, TPrimaryKey, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
        where TUpdateInput : class, IEntityDto<TPrimaryKeyDto>
        where TCreateInput : class, IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IDeleteCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> _deleteCommandService;
        public CrudEndpoint(
            IDeleteCommandService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> deleteCommandService,
            ICreateCommandService<TEntity, TPrimaryKey, TCreateInput, TPrimaryKeyDto> createCommandService,
            IUpdateCommandService<TEntity, TPrimaryKey, TUpdateInput, TPrimaryKeyDto> updateCommandService,
            IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService
        )
            : base(createCommandService, updateCommandService, queryService)
        {
            _deleteCommandService = deleteCommandService;
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(TPrimaryKeyDto id)
        {
            await _deleteCommandService.Delete(id);
        }
    }
}
