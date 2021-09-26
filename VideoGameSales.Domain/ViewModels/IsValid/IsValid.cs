using System;
using FluentValidation.Results;

namespace VideoGameSales.Domain.ViewModels.IsValid
{
    public class IsValid<T>
    {
        public IsValid() {}
        public IsValid(T Response, ValidationResult valid)
        {
            Data = Response;
            Valid = valid;
        }

        public T Data {get; set;}
        public ValidationResult Valid { get; set;}
    }
}
