using System;
using FluentValidation;
using VideoGameSales.Core.GameToPublisher.Query;
namespace VideoGameSales.Core.FIlters.validators.GameToPublisher
{
    public class GetGameToPublisherValidator : AbstractValidator<GetGameToPublisherByIdQuery>
    {
        public GetGameToPublisherValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
