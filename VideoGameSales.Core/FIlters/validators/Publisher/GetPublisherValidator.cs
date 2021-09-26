using System;
using FluentValidation;
using VideoGameSales.Core.Publishers.Query;

namespace VideoGameSales.Core.FIlters.validators.Publisher
{
    public class GetPublisherValidator : AbstractValidator<GetPublisherByIdQuery>
    {
        public GetPublisherValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
