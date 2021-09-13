using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Connectors;

namespace VideoGameSales.Core.GameToPublisher.Query
{
    public class GetGameToPublisherByIdQuery : IRequest<GameToPublisherViewModel>
    {

        public int Id { get; set; }

        public GetGameToPublisherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
