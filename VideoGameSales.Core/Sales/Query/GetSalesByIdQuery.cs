using System;
using MediatR;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Sales.Query
{
    public class GetSalesByIdQuery : IRequest<IsValid<Sale>>
    {
        public int Id { get; set; }
        public GetSalesByIdQuery(int id)
        {
            Id = id;
        }
    }
}
