using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class CreateGameToPlatformCommand :IRequest<IsValid<GamesToPlataform>>
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }
    }
}
