using System;
using FluentValidation;
using VideoGameSales.Core.GameToPublisher.Command;
namespace VideoGameSales.Core.FIlters.validators.GameToPublisher
{
    public class DeleteGameToPublisherValidator : AbstractValidator<DeleteGameToPublisherByIdCommand>
    {
        public DeleteGameToPublisherValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
