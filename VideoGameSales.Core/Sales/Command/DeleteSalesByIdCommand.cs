using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Sales.Command
{
    public class DeleteSalesByIdCommand : IRequest<IsValid<bool>>
    {
        public int Id { get; set; }
        public DeleteSalesByIdCommand(int id)
        {
            Id = id;
        }
    }
}
