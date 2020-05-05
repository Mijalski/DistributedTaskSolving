using System.Collections.Generic;

namespace DistributedTaskSolving.Application.Generics.Dto.Results
{
    public class PagedResultDto<TEntityDto>
    {
        public PagedResultDto(int totalCount, IReadOnlyList<TEntityDto> items)
        {
            TotalCount = totalCount;
            Items = items;
        }

        public int TotalCount { get; set; }
        public IReadOnlyList<TEntityDto> Items { get; set; }
    }
}