using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Shared
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }

        public IEnumerable<T> Data { get; set; }

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageIndex = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;

            Data = items;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
                var count = await source.CountAsync();
                var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();

                return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
        public static PaginatedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
