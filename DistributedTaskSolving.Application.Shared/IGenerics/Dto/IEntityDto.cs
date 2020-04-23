namespace DistributedTaskSolving.Application.Shared.IGenerics.Dto
{
    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}