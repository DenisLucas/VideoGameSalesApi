using System;
using FluentValidation;
using VideoGameSales.Core.GameToPlatform.Command;
namespace VideoGameSales.Core.FIlters.validators.GameToPlataform
{
    public class DeleteGameToPlatformValidator : AbstractValidator<DeleteGameToPlatformByIdCommand>
    {
        public DeleteGameToPlatformValidator()
        {
            RuleFor(x=> x.Id)
                .NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Must be a valid Id");
        }
    }
}
