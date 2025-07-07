using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationInResponse<T>(this HttpContext httpContext, IQueryable<T> Queryable, int recordsPerPage)
        {
            double count = await Queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }
        public static void InsertPaginationInResponseSync<T>(this HttpContext httpContext, IQueryable<T> Queryable, int recordsPerPage)
        {
            double count = Queryable.Count();
            double pagesQuantity = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }
    }
}
