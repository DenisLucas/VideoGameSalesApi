using System;
using System.Collections.Generic;

namespace VideoGameSales.Core.Pagination
{
    public class PageResponse<T>
    {
        public PageResponse(){}
        public PageResponse(IEnumerable<T> Data)
        {
            
        }

        public IEnumerable<T> Data { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string NextPage { get; set; }
        public string LastPage { get; set; }
    }
}
