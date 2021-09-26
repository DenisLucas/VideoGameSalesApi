using System;
using FluentValidation;
using VideoGameSales.Core.GameToPlatform.Command;

namespace VideoGameSales.Core.FIlters.validators.GameToPlataform
{
    public class CreateGameToPlatformValidator : AbstractValidator<CreateGameToPlatformCommand>
    {
        public CreateGameToPlatformValidator()
        {
            RuleFor(x => x.GameId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.PlatformId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
