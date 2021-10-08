using System;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.Games.Query
{
    public class GetAllGamesFilterQuery
    {
        
        public int Ranks { get; set; }        
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Release_year { get; set; }
        public int Platform { get; set; }
        public int Publisher { get; set; }
    }
}
