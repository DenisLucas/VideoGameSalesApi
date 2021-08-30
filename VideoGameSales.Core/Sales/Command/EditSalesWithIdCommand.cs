using System;
using MediatR;
using VideoGameSales.Domain.Entities.Sales;

namespace VideoGameSales.Core.Sales.Command
{
    public class EditSalesWithIdCommand : IRequest<Sale>
    {
        public int Id { get; set; }
        public EditSalesCommand Sales { get; set; }

        public EditSalesWithIdCommand(int id, EditSalesCommand sales)
        {
            Id = id;
            Sales = sales;
        }
    }
}
