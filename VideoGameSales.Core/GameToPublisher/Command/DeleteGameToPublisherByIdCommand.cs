using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPublisher.Command
{
    public class DeleteGameToPublisherByIdCommand : IRequest<bool>
    {

        public int Id { get; set; }

        public DeleteGameToPublisherByIdCommand(int id)
        {
            Id = id;
        }
    }
}
