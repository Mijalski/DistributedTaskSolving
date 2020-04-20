using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Generics.Dto.Requests;
using DistributedTaskSolving.Application.Generics.Dto.Results;
using DistributedTaskSolving.Application.Generics.Helpers;
using DistributedTaskSolving.Application.Generics.MatchingStrategies;
using DistributedTaskSolving.Application.IGenerics.Endpoints;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Dto;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace DistributedTaskSolving.Application.Generics.Endpoints
{
    [EndpointNameConvention]
    [ApiController]
    [Route("api/[controller]")]
    public class QueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> : IQueryEndpoint<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto>
        where TEntity : class, IEntity<TPrimaryKey>, IHaveUniqueName<TPrimaryKeyDto>
        where TGetOutput : class, IEntityDto<TPrimaryKeyDto>
    {
        protected readonly IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> _queryService;

        public QueryEndpoint(IQueryService<TEntity, TPrimaryKey, TGetOutput, TPrimaryKeyDto> queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("{id}")]
        public virtual async Task<TGetOutput> Get(TPrimaryKeyDto id)
        {
            return await _queryService.Get(id);
        }

        [HttpGet]
        public virtual async Task<PagedResultDto<TGetOutput>> GetAll(string sorting = null, int maxResultCount = 10, int skipCount = 0)
        {
            var query = _queryService.GetAll();

            var totalCount = await query.CountAsync();

            var pagedAndSortedRequestDto = new PagedAndSortedRequestDto(sorting, maxResultCount, skipCount);

            query = QueryServiceHelper.ApplySorting(query, pagedAndSortedRequestDto);
            query = QueryServiceHelper.ApplyPaging(query, pagedAndSortedRequestDto);

            var mappedList = await query.ToListAsync();

            return new PagedResultDto<TGetOutput>(
                totalCount,
                mappedList
            );
        }

    }
}