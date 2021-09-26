using System;
using MediatR;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Sales.Query
{
    public class GetSalesByIdQuery : IRequest<IsValid<Sale>>
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
