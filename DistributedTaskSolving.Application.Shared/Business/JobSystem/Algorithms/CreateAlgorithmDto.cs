using DistributedTaskSolving.Application.Shared.Generics.Dto;
using MediatR;

namespace DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms
{
    public class CreateAlgorithmDto
    {
        public string Name { get; set; }
        public byte[] Code { get; set; }
        public string JobTypeName { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}