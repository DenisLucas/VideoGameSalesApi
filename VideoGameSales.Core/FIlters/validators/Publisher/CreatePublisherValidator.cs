using System;
using FluentValidation;
using VideoGameSales.Core.Publishers.Command;

namespace VideoGameSales.Core.FIlters.validators.Publisher
{
    public class CreatePublisherValidator : AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherValidator()
        {
            RuleFor(x=> x.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable name");

        }
    }
}
