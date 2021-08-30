using System;
using MediatR;
using VideoGameSales.Domain.Entities.Sales;

namespace VideoGameSales.Core.Sales.Query
{
    public class GetSalesByIdQuery : IRequest<Sale>
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        public GetSalesByIdQuery(int gameId, int platformId)
        {
            GameId = gameId;
            PlatformId = platformId;
        }
    }
}
