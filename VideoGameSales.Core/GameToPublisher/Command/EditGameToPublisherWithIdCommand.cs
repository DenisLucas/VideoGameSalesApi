using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class EditGameToPublisherWithIdCommand : IRequest<GamesToPublisher>
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
