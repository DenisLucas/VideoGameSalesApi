using System;
using FluentValidation;
using VideoGameSales.Core.GameToPlatform.Query;
namespace VideoGameSales.Core.FIlters.validators.GameToPlataform
{
    public class GetGameToPlatformValidator : AbstractValidator<GetGameToPlatformByIdQuery>
    {
        public GetGameToPlatformValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
