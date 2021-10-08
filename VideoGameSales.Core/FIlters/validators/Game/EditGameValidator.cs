using System;
using FluentValidation;
using VideoGameSales.Core.Games.Command;
namespace VideoGameSales.Core.FIlters.validators.Game
{
    public class EditGameValidator : AbstractValidator<EditGameWithIdCommand>
    {
        public EditGameValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.Game.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable name");

            RuleFor(x => x.Game.Genre)
            .NotEmpty().WithMessage("Genre can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable genre");
            
            RuleFor(x => x.Game.Release_year)
            .NotEmpty().WithMessage("Give a valid Date")
            .GreaterThan(1950).WithMessage("Release year must be grater Than 1950");

        }
    }
}
