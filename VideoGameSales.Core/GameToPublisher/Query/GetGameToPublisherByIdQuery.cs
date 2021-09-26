using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPublisher.Query
{
    public class GetGameToPublisherByIdQuery : IRequest<IsValid<GameToPublisherViewModel>>
    {

        public int Id { get; set; }

        public GetGameToPublisherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
