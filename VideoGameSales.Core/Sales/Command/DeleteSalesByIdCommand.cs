using System;

namespace VideoGameSales.Core.Sales.Command
{
    public class DeleteSalesByIdCommand
    {
        public int Id { get; set; }
        public DeleteSalesByIdCommand(int id)
        {
            Id = id;
        }
    }
}
