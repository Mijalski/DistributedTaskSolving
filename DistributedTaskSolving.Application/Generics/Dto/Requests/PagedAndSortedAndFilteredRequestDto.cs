namespace DistributedTaskSolving.Application.Generics.Dto.Requests
{
    public class PagedAndSortedAndFilteredRequestDto : PagedAndSortedRequestDto
    {
        public PagedAndSortedAndFilteredRequestDto(string filter, string sorting, int maxResultCount, int skipCount) 
            : base(sorting, maxResultCount, skipCount)
        {
            Filter = filter;
        }

        public virtual string Filter { get; set; }

    }
}