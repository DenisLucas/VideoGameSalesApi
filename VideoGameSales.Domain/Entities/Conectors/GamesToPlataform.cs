using System;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.Entities.Platforms;

namespace VideoGameSales.Domain.Entities.Conectors
{
    public class GamesToPlataform
    {
        public int Id { get; set; }
        public int Platform_id { get; set; }
        public int Games_id { get; set; }

        
        public Platform Platform { get; set; }
        public Game Games { get; set; }
    }
}
