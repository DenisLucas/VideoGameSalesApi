using System;
using FluentValidation;
using VideoGameSales.Core.Platforms.Command;

namespace VideoGameSales.Core.FIlters.validators.Platform
{
    public class CreatePlatformValidator : AbstractValidator<CreatePlatformCommand>
    {
        public CreatePlatformValidator()
        {
            RuleFor(x=> x.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable name");

        }
    }
}
