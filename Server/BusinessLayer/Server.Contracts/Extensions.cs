using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contracts
{
    public static class Extensions
    {
        public static PagedResult<TSource> ToPagedResult<TSource>(this IQueryable<TSource> source, DataRequest request)
        {
            int pageCount = 0;
            int totalCount = source.Count();
            int rem = totalCount % request.PageSize;
            if (totalCount <= request.PageSize) pageCount = 1;
            else if (rem == 0) pageCount = totalCount / request.PageSize;
            else pageCount = totalCount / request.PageSize + 1;
            var result = new PagedResult<TSource>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Data = source.
                    Skip(request.PageSize * (request.Page - 1)).
                    Take(request.PageSize).ToArray(),
                Total = pageCount
            };
            return result;
        }
    }
}
