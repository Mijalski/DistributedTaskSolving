namespace DistributedTaskSolving.Business.IGenerics
{
    public interface IHaveUniqueName<TKey>
    {
        TKey Name { get; set; }
    }
}