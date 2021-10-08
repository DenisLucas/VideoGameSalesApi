using System;
using FluentValidation;
using VideoGameSales.Core.Platforms.Command;

namespace VideoGameSales.Core.FIlters.validators.Platform
{
    public class EditPlatformValidator : AbstractValidator<EditPlatformWithIdCommand>
    {
        public EditPlatformValidator()
        {
            
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.Platform.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable name");
        }
    }
}
