using System;

namespace VideoGameSales.Core.Pagination
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            Page = 1;
            PageSize = 50;
        }

        public PaginationQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
