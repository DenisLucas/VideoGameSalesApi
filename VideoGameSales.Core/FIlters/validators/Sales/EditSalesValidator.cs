using System;
using FluentValidation;
using VideoGameSales.Core.Sales.Command;
namespace VideoGameSales.Core.FIlters.validators.Sales
{
    public class EditSalesValidator : AbstractValidator<EditSalesWithIdCommand>
    {
        public EditSalesValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Must be a valid Id");
            RuleFor(x => x.Sales.Sales_Eu)
                .GreaterThanOrEqualTo(0).WithMessage("must be greater or equal than 0");
            RuleFor(x => x.Sales.Sales_Global)
                .GreaterThanOrEqualTo(0).WithMessage("must be greater or equal than 0");
            RuleFor(x => x.Sales.Sales_Jp)
                .GreaterThanOrEqualTo(0).WithMessage("must be greater or equal than 0");
            RuleFor(x => x.Sales.Sales_Other)
                .GreaterThanOrEqualTo(0).WithMessage("must be greater or equal than 0");
            RuleFor(x => x.Sales.Sales_Na)
                .GreaterThanOrEqualTo(0).WithMessage("must be greater or equal than 0");
        }
    }
}
