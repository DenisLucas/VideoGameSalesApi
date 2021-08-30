using System;
using MediatR;
using VideoGameSales.Domain.Entities.Games;

namespace VideoGameSales.Core.Games.Command
{
    public class EditGameWithIdCommand : IRequest<Game>
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
