using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class DeleteGameToPublisherByIdCommand : IRequest<PublishersToGames>
    {

        public int Id { get; set; }

        public DeleteGameToPublisherByIdCommand(int id)
        {
            Id = id;
        }
    }
}
