namespace DistributedTaskSolving.Application.Generics.Requests
{
    public interface IGetRequest<TPrimaryKeyDto>
    {
        TPrimaryKeyDto Id { get; set; }    
    }
}