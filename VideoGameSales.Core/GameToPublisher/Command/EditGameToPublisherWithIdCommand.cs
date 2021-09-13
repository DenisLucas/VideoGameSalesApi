using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPublisher.Command
{
    public class EditGameToPublisherWithIdCommand : IRequest<PublishersToGames>
    {
        public int Id { get; set; }
        public EditGameToPublisherCommand GameToPublisher { get; set; }

        public EditGameToPublisherWithIdCommand(int id, EditGameToPublisherCommand gameToPublisher)
        {
            Id = id;
            GameToPublisher = gameToPublisher;
        }
    }
}
