using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditSalesWithIdCommandHandler : IRequestHandler<EditSalesWithIdCommand, Sale>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditSalesWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> Handle(EditSalesWithIdCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Sales.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            game.Sales_Eu = request.Sales.Sales_Eu;
            game.Sales_Global = request.Sales.Sales_Global;
            game.Sales_Jp = request.Sales.Sales_Jp;
            game.Sales_Na = request.Sales.Sales_Na;
            game.Sales_Other = request.Sales.Sales_Other;
            game.GamesToPlatforms_id = request.Sales.GamesToPlatforms_id;

            await _context.SaveChangesAsync();
            return game;
        }
    }
}
