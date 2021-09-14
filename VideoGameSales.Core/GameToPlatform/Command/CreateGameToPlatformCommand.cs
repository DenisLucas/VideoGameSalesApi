using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class CreateGameToPlatformCommand :IRequest<GamesToPlataform>
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }
    }
}
