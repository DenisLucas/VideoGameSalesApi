using System;
using System.Collections.Generic;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;

namespace VideoGameSales.Domain.ViewModels.Games
{
    public class GameViewModel
    {
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
        public List<string> platforms { get; set; }
        public string publisher { get; set; }        
    }
}
