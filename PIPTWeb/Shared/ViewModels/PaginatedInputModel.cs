using System.Collections.Generic;

namespace PIPTWeb.Shared.ViewModels
{
    public class PaginatedInputModel
    {
        public IEnumerable<SortingUtility.SortingParams> SortingParams { set; get; }
        public IEnumerable<FilterUtility.FilterParams> FilterParams { get; set; }
        public IEnumerable<string> GroupingColumns { get; set; } = null;
        private int pageNumber = 1;
        public int PageNumber { get { return pageNumber; } set { if (value > 1) pageNumber = value; else pageNumber = 1; } }

        private int pageSize = 100;
        public int PageSize
        { 
            get 
            {
                return pageSize;
            }
            set
            {
                if (value > 1)
                    pageSize = value;
                else if (value > pageSize)
                    pageSize = 100;
            }
        }
        private int pagesQuantity = 1;
        public int PagesQuantity { get { return pagesQuantity; } set { if (value > 1) pagesQuantity = value; } }
    }
}
