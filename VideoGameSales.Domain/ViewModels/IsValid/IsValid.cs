using System;
using FluentValidation.Results;

namespace VideoGameSales.Domain.ViewModels.IsValid
{
    public class IsValid<T>
    {
        public IsValid() {}
        public IsValid(T Response, ValidationResult valid, int Id = 0 )
        {
            Data = Response;
            Valid = valid;
        }

        public T Data {get; set;}

        public int? Id {get; set;}
        public ValidationResult Valid { get; set;}
    }
}
