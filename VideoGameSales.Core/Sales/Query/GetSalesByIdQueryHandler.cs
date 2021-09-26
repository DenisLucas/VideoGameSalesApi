using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Sales;
using VideoGameSales.Core.Sales.Query;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetSalesByIdQueryHandler : IRequestHandler<GetSalesByIdQuery, IsValid<Sale>>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetSalesByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Sale>> Handle(GetSalesByIdQuery request, CancellationToken cancellationToken)
        {

            var validator = new GetSalesValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Sale>(new Sale(),isValid);
            }
            
            var idList = await _context.Sales.Select(x => x.GamesToPlatforms_id).ToListAsync();
            if (idList.Contains(request.GameId) && idList.Contains(request.PlatformId))
            {
            var gameToPlatform = await _context.GamesToPlataform.Where(x => x.Games_id == request.GameId && x.Platform_id == request.PlatformId).FirstOrDefaultAsync();
            return new IsValid<Sale>(await _context.Sales.Where(x => x.GamesToPlatforms_id == gameToPlatform.Id).FirstOrDefaultAsync(),isValid);    
            }
            return new IsValid<Sale>();
        }
    }
}
