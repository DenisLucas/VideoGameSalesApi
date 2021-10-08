using System;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.Entities.Publishers;

namespace VideoGameSales.Domain.Entities.Conectors
{
    public class PublishersToGames
    {
        public int Id { get; set; }
        public int Publishers_id { get; set; }
        public int Games_id { get; set; }
        public Publisher Publisher { get; set; }
        public Game Games { get; set; }
        
    }
}
