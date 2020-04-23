
namespace DistributedTaskSolving.Application.Generics.Dto.Requests
{
    public class PagedAndSortedRequestDto : PagedRequestDto
    {
        public PagedAndSortedRequestDto(string sorting, int maxResultCount, int skipCount) 
            : base(maxResultCount,skipCount)
        {
            Sorting = sorting;
        }

        public string Sorting { get; set; }
    }
}