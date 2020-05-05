using DistributedTaskSolving.Application.Shared.IGenerics.Dto;

namespace DistributedTaskSolving.Application.Shared.Generics.Dto
{
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}