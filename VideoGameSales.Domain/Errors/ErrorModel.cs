using System;

namespace VideoGameSales.Domain.Errors
{
    public class ErrorModel
    {
        public string FieldName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
