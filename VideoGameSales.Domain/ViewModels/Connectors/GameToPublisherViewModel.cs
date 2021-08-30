using System;

namespace VideoGameSales.Domain.ViewModels.Connectors
{
    public class GameToPublisherViewModel
    {

        public int GameId { get; set; }
        public string GameName { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
    }
}
