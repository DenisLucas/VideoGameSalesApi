using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Query
{
    public class GetGameToPublisherByIdQuery : IRequest<GamesToPublisher>
    {

        public int Id { get; set; }

        public GetGameToPublisherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
