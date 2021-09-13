using System;
using MediatR;

namespace VideoGameSales.Core.Sales.Command
{
    public class DeleteSalesByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteSalesByIdCommand(int id)
        {
            Id = id;
        }
    }
}
