using System;
using MediatR;
using System.Collections.Generic;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Core.Games.Command
{
    public class CreateGameCommand : IRequest<IsValid<GameViewModel>>
    {
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
        public List<int> Platform_Id { get; set; }
        public int Publisher_id { get; set; }
    }
}
