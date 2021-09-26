using System;
using FluentValidation;
using VideoGameSales.Core.GameToPublisher.Command;

namespace VideoGameSales.Core.FIlters.validators.GameToPublisher
{
    public class EditGameToPublisherValidator : AbstractValidator<EditGameToPublisherWithIdCommand>
    {
        public EditGameToPublisherValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.GameToPublisher.GameId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.GameToPublisher.PublisherId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
