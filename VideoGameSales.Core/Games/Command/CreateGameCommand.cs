using System;
using MediatR;
using System.Collections.Generic;
using VideoGameSales.Domain.Entities.Games;

namespace VideoGameSales.Core.Games.Command
{
    public class CreateGameCommand : IRequest<Game>
    {
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
        public List<int> Platform_Id { get; set; }
        public int Publisher_id { get; set; }
    }
}
