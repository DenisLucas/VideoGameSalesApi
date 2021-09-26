using System;
using System.Collections.Generic;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.Entities.Games;

namespace VideoGameSales.Domain.Entities.Publishers
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PublishersToGames> GamesToPublisher { get; set; }
    }
}
