using System;
using FluentValidation;
using VideoGameSales.Core.Games.Query;

namespace VideoGameSales.Core.FIlters.validators.Game
{
    public class GetAllGamesValidator : AbstractValidator<GetAllGamesFilterQuery>
    {
        public GetAllGamesValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotEqual("string");

            RuleFor(x => x.Genre)
            .NotEmpty()
            .NotEqual("string");
            
            RuleFor(x => x.Release_year)
            .NotEmpty()
            .GreaterThan(1950);

            RuleFor(x => x.Platform)
            .NotEmpty();

            RuleFor(x => x.Publisher)
            .NotEmpty();  
        }
    }
}
