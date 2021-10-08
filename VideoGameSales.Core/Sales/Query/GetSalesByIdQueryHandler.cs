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
            
            var idList = await _context.Sales.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
            return new IsValid<Sale>(await _context.Sales.Where(x => x.Id == request.Id).FirstOrDefaultAsync(),isValid);    
            }
            return new IsValid<Sale>();
        }
    }
}
