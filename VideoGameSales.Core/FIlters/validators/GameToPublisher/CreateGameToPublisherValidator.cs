using System;
using FluentValidation;
using VideoGameSales.Core.GameToPublisher.Command;
namespace VideoGameSales.Core.FIlters.validators.GameToPublisher
{
    public class CreateGameToPublisherValidator : AbstractValidator<CreateGameToPublisherCommand>
    {
        public CreateGameToPublisherValidator()
        {
            RuleFor(x => x.GameId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.PublisherId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
