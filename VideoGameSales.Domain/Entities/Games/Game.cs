using System;
using System.Collections.Generic;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.Entities.Publishers;

namespace VideoGameSales.Domain.Entities.Games
{
    public class Game
    {
        public int Id { get; set; }
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
        public List<GamesToPlataform> Platform { get; set; }
        public PublishersToGames Publisher { get; set; }
        
    }
}
