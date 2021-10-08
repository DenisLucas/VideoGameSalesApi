using System;
using FluentValidation;
using VideoGameSales.Core.Games.Command;

namespace VideoGameSales.Core.FIlters.validators.Game
{
    public class CreateGameValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable name");

            RuleFor(x => x.Genre)
            .NotEmpty().WithMessage("Genre can't be empty")
            .NotEqual("string").WithMessage("string is not an acceptable genre");
            
            RuleFor(x => x.Release_year)
            .NotEmpty().WithMessage("Give a valid Date")
            .GreaterThan(1950).WithMessage("Release year must be grater Than 1950");

            RuleFor(x => x.Platform_Id)
            .NotEmpty().WithMessage("Platform id can't be empty");

            RuleFor(x => x.Publisher_id)
            .NotEmpty().WithMessage("Publisher id can't be empty");
            
        }
    }
}
