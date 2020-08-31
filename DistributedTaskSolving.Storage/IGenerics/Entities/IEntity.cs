namespace DistributedTaskSolving.Business.IGenerics.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}