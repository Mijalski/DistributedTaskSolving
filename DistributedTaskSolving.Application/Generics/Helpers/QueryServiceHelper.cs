using System.Linq;
using System.Linq.Dynamic.Core;
using DistributedTaskSolving.Application.Generics.Dto.Requests;

namespace DistributedTaskSolving.Application.Generics.Helpers
{
    public class QueryServiceHelper
    {
        public static IQueryable<TGetOutput> ApplySorting<TGetOutput>(IQueryable<TGetOutput> query, PagedAndSortedRequestDto input)
        {
            return string.IsNullOrEmpty(input.Sorting) ? query : query.OrderBy(input.Sorting);
        }

        public static IQueryable<TGetOutput> ApplyPaging<TGetOutput>(IQueryable<TGetOutput> query, PagedRequestDto input)
        {
            return query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
        }
    }
}