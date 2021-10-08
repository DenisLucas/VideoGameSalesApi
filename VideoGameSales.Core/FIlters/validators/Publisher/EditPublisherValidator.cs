using System;
using FluentValidation;
using VideoGameSales.Core.Publishers.Command;

namespace VideoGameSales.Core.FIlters.validators.Publisher
{
    public class EditPublisherValidator : AbstractValidator<EditPublisherWithIdCommand>
    {
        public EditPublisherValidator()
        {
            
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.Publisher.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable name");
        }
    }
}
