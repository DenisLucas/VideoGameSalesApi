using System;
using FluentValidation;
using VideoGameSales.Core.Games.Command;
namespace VideoGameSales.Core.FIlters.validators.Game
{
    public class DeleteGameValidator : AbstractValidator<DeleteGameByIdCommand>
    {
        public DeleteGameValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
        }
    }
}
