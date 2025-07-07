using System.Collections.Generic;

namespace PIPTWeb.Shared.ViewModels
{
    public class ResultApiModel<T>
    {
        public string Status { get; set; } = "succsess";
        public IEnumerable<T> Data { get; set; }
        public int Records { get; set; } = 0;
        public string Code { get; set; }
        public string Message { get; set; }
        public PaginatedInputModel Pagination { get; set; }
    }
}
