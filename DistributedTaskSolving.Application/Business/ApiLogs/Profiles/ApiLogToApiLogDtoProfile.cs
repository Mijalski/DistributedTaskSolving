using System;
using DistributedTaskSolving.Application.Shared.Business.ApiLogs.Dto;
using DistributedTaskSolving.Business.BusinessEntities.ApiLogs;

namespace DistributedTaskSolving.Application.Business.ApiLogs.Profiles
{
    public class ApiLogToApiLogDtoProfile : AutoMapper.Profile
    {
        public ApiLogToApiLogDtoProfile()
        {
            CreateMap<ApiLog, ApiLogDto>();
        }
    }
}