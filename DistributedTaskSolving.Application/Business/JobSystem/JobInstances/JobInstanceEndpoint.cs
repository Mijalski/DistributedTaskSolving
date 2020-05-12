using System;
using System.Threading.Tasks;
using AutoMapper;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandHandlers;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.QueryHandlers;
using DistributedTaskSolving.Application.Generics.Endpoints;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances
{
    public class JobInstanceEndpoint : CrudEndpoint<JobInstanceDto, long, JobInstanceQuery, UpdateJobInstanceCommand, CreateJobInstanceCommand, DeleteJobInstanceCommand>
    {
        public JobInstanceEndpoint(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}