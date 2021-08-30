using System;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class EditGameToPublisherCommand
    {
        public int GameId { get; set; }
        public int PublisherId { get; set; }
    }
}
