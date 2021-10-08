using System;

namespace VideoGameSales.Core.Pagination
{
    public class Response<T>
    {
        public Response() {}
        public Response(T Response)
        {
            Data = Response;
        }

        public T Data {get; set;}
    }
}
