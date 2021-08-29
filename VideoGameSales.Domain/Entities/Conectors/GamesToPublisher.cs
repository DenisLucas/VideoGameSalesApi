using System;

namespace VideoGameSales.Domain.Entities.Conectors
{
    public class GamesToPublisher
    {
        public int Id { get; set; }
        public int Publisher_id { get; set; }
        public int Games_id { get; set; }
    }
}
