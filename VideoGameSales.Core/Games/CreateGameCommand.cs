using System;
using MediatR;
using VideoGameSales.Domain.Entities.Games;

namespace VideoGameSales.Core.Games
{
    public class CreateGameCommand : IRequest<Game>
    {
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
    }
}
