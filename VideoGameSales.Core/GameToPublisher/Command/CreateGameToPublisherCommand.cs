using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPublisher.Command
{
    public class CreateGameToPublisherCommand :IRequest<IsValid<PublishersToGames>>
    {
        public int GameId { get; set; }
        public int PublisherId { get; set; }
    }
}
