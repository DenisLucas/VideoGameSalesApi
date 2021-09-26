using System;
using FluentValidation;
using VideoGameSales.Core.GameToPlatform.Command;
namespace VideoGameSales.Core.FIlters.validators.GameToPlataform
{
    public class EditGameToPlatformValidator : AbstractValidator<EditGameToPlatformWithIdCommand>
    {
        public EditGameToPlatformValidator()
        {
            
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.GameToPlatform.GameId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.GameToPlatform.PlatformId).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
