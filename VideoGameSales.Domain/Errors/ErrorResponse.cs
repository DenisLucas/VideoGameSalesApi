using System;
using System.Collections.Generic;

namespace VideoGameSales.Domain.Errors
{
    public class ErrorResponse
    {
        public List<ErrorModel> ErrorMessage { get; set; } = new List<ErrorModel>();
    }
}
