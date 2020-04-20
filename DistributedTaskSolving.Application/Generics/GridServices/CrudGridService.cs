using System.Threading.Tasks;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using GridShared;

namespace DistributedTaskSolving.Application.Generics.GridServices
{
    public class CrudGridService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> : ICrudGridService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto>
        where TEntityDto : class, IEntityDto<TPrimaryKeyDto>
    {
        private readonly IQueryService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> _queryService;
        private readonly IUpdateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> _updateCommandService;
        private readonly ICreateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> _createCommandService;
        private readonly IDeleteCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> _deleteCommandService;

        public CrudGridService(IQueryService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> queryService, 
            IUpdateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> updateCommandService,
            ICreateCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> createCommandService, 
            IDeleteCommandService<TEntity, TPrimaryKey, TEntityDto, TPrimaryKeyDto> deleteCommandService
            )
        {
            _queryService = queryService;
            _updateCommandService = updateCommandService;
            _createCommandService = createCommandService;
            _deleteCommandService = deleteCommandService;
        }

        public async Task<TEntityDto> Get(params object[] keys)
        {
            var id = (TPrimaryKeyDto) keys[0];
            return await _queryService.Get(id);
        }

        public async Task Insert(TEntityDto item)
        {
            await _createCommandService.Create(item);
        }

        public async Task Update(TEntityDto item)
        {
            await _updateCommandService.Update(item, item.Id);
        }

        public async Task Delete(params object[] keys)
        {
            var id = (TPrimaryKeyDto)keys[0];
            await _deleteCommandService.Delete(id);
        }
    }
}