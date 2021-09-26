using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPublisher.Command
{
    public class DeleteGameToPublisherByIdCommand : IRequest<IsValid<bool>>
    {

        public int Id { get; set; }

        public DeleteGameToPublisherByIdCommand(int id)
        {
            Id = id;
        }
    }
}
