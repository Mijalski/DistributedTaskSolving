using System;
using DistributedTaskSolving.Application.Shared.Generics;
using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto
{
    public class JobInstanceDto : FullAuditedEntityDto<long>
    {
        public string Key { get; set; }
        public string Result { get; set; }
        public bool IsSolved { get; set; }
        public byte[] AlgorithmCode { get; set; }
        public string AlgorithmName { get; set; }
        public long AlgorithmId { get; set; }
        public string JobTypeName { get; set; }
        public Guid JobTypeId { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
    }
}