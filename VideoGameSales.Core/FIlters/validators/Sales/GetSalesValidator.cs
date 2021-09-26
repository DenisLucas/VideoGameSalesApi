using System;
using FluentValidation;
using VideoGameSales.Core.Sales.Query;

namespace VideoGameSales.Core.FIlters.validators.Sales
{
    public class GetSalesValidator : AbstractValidator<GetSalesByIdQuery>
    {
        public GetSalesValidator()
        {
            RuleFor(x=> x.GameId)
                .NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Must be a valid Id");
        }
    }
}
