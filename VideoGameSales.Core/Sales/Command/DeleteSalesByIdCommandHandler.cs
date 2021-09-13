using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeleteSalesByIdCommandHandler : IRequestHandler<DeleteSalesByIdCommand, bool>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteSalesByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteSalesByIdCommand request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            _context.Sales.Remove(sale);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
