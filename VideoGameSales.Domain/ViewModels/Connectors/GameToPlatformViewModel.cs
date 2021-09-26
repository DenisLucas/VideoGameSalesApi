using System;

namespace VideoGameSales.Domain.ViewModels.Connectors
{
    public class GameToPlatformViewModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
        
    }
}
