using System;
using FluentValidation;
using VideoGameSales.Core.Sales.Command;
namespace VideoGameSales.Core.FIlters.validators.Sales
{
    public class DeleteSalesValidator : AbstractValidator<DeleteSalesByIdCommand>
    {
        public DeleteSalesValidator()
        {
            RuleFor(x=> x.Id)
                .NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Must be a valid Id");
        }
    }
}
