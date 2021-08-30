using System;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class EditGameToPlatformCommand
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }
    }
}
