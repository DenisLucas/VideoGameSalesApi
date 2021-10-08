using System;
using FluentValidation;
using VideoGameSales.Core.Publishers.Command;

namespace VideoGameSales.Core.FIlters.validators.Publisher
{
    public class DeletePublisherValidator : AbstractValidator<DeletePublisherByIdCommand>
    {
        public DeletePublisherValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
