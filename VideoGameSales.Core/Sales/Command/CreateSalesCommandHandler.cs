using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Sales.Command
{
    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommand, Sale>
    {
        private readonly VideoGameSalesDbContext _context;

        public CreateSalesCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale
                {
                    Sales_Eu = request.Sales_Eu,
                    Sales_Global = request.Sales_Global,
                    Sales_Jp = request.Sales_Jp,
                    Sales_Na = request.Sales_Na,
                    Sales_Other = request.Sales_Other,
                    GamesToPlatforms_id = request.GamesToPlatforms_id
                };

            var saldeDb = await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();

            return sale;
        }
    }
}
