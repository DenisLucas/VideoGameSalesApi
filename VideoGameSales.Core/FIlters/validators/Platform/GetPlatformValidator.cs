using System;
using FluentValidation;
using VideoGameSales.Core.Platforms.Query;

namespace VideoGameSales.Core.FIlters.validators.Platform
{
    public class GetPlatformValidator : AbstractValidator<GetPlatformByIdQuery>
    {
        public GetPlatformValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
