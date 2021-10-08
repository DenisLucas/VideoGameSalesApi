using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Games.Command
{
    public class EditGameWithIdCommand : IRequest<IsValid<GameViewModel>>
    {
        public int Id { get; set; }
        public EditGameCommand Game { get; set; }
        public EditGameWithIdCommand(int id, EditGameCommand game)
        {
            Id = id;
            Game = game;
        }
    }
}
