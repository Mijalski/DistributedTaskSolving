using DistributedTaskSolving.Business.IGenerics.Entities;

namespace DistributedTaskSolving.Business.Generics.Entities
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public class Entity : Entity<long>
    {
    }
}