using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Sales.Query;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetSalesByIdQueryHandler : IRequestHandler<GetSalesByIdQuery, Sale>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetSalesByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> Handle(GetSalesByIdQuery request, CancellationToken cancellationToken)
        {
            var gameToPlatform = await _context.GamesToPlataform.Where(x => x.Games_id == request.GameId && x.Platform_id == request.PlatformId).FirstOrDefaultAsync();
            return await _context.Sales.Where(x => x.GamesToPlatforms_id == gameToPlatform.Id).FirstOrDefaultAsync();
        }
    }
}
