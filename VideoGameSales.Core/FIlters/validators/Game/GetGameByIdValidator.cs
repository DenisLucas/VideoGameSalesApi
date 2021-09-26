using System;
using FluentValidation;
using VideoGameSales.Core.Games.Query;

namespace VideoGameSales.Core.FIlters.validators.Game
{
    public class GetGameByIdValidator : AbstractValidator<GetGameByIdQuery>
    {
        public GetGameByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
