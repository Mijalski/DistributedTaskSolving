using System;
using AutoMapper;
using DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandHandlers;
using DistributedTaskSolving.Application.Business.JobSystem.Algorithms.QueryHandlers;
using DistributedTaskSolving.Application.Generics.Endpoints;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using MediatR;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobTypes
{
    public class JobTypeEndpoint : CrudEndpoint<AlgorithmDto, long, AlgorithmQuery, UpdateAlgorithmCommand, CreateAlgorithmCommand, DeleteAlgorithmCommand>
    {
        public JobTypeEndpoint(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}