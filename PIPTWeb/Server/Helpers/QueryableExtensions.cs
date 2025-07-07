using PIPTWeb.Shared;
using System.Linq;

namespace PIPTWeb.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> Queryable, PaginationItems pagination)
        {
            return Queryable
                .Skip((pagination.Page - 1) * pagination.Limit)
                .Take(pagination.Limit);
        }
    }
}
