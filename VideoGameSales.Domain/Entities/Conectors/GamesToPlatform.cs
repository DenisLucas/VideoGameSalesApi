using System;

namespace VideoGameSales.Domain.Entities.Conectors
{
    public class GamesToPlatform
    {
        public int Id { get; set; }
        public int Platform_id { get; set; }
        public int Games_id { get; set; }
    }
}
