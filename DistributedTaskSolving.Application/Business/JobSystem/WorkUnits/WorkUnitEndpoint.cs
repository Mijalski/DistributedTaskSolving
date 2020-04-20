using System;
using DistributedTaskSolving.Application.Generics.Endpoints;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;

namespace DistributedTaskSolving.Application.Business.JobSystem.WorkUnits
{
    public class WorkUnitEndpoint : CreateUpdateQueryEndpoint<WorkUnit, long, WorkUnitDto, long>
    {
        public WorkUnitEndpoint(
            ICreateCommandService<WorkUnit, long, WorkUnitDto, long> createCommandService,
            IUpdateCommandService<WorkUnit, long, WorkUnitDto, long> updateCommandService,
            IQueryService<WorkUnit, long, WorkUnitDto, long> queryService)
            : base(createCommandService, updateCommandService, queryService)
        {
        }
    }
}