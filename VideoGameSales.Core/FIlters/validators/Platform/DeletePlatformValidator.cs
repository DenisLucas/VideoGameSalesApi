using System;
using FluentValidation;
using VideoGameSales.Core.Platforms.Command;

namespace VideoGameSales.Core.FIlters.validators.Platform
{
    public class DeletePlatformValidator : AbstractValidator<DeletePlatformByIdCommand>
    {
        public DeletePlatformValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
