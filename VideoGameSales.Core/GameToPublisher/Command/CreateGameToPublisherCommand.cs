using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPublisher.Command
{
    public class CreateGameToPublisherCommand :IRequest<PublishersToGames>
    {
        public int GameId { get; set; }
        public int PublisherId { get; set; }
    }
}
