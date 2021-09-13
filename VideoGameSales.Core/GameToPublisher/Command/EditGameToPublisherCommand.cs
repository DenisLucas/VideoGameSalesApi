using System;

namespace VideoGameSales.Core.GameToPublisher.Command
{
    public class EditGameToPublisherCommand
    {
        public int GameId { get; set; }
        public int PublisherId { get; set; }
    }
}
