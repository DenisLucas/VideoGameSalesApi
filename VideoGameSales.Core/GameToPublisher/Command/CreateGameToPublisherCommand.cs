using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class CreateGameToPublisherCommand :IRequest<GamesToPublisher>
    {
        public int GameId { get; set; }
        public int PublisherId { get; set; }
    }
}
