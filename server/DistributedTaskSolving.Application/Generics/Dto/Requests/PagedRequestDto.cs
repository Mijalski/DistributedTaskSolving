using System.ComponentModel.DataAnnotations;

namespace DistributedTaskSolving.Application.Generics.Dto.Requests
{
    public class PagedRequestDto
    {
        public PagedRequestDto(int maxResultCount, int skipCount)
        {
            MaxResultCount = maxResultCount;
            SkipCount = skipCount;
        }

        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }

        [Range(1, int.MaxValue)]
        public virtual int MaxResultCount { get; set; } = 10;
    }
}