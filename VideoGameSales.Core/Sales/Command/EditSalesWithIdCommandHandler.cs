using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Sales;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditSalesWithIdCommandHandler : IRequestHandler<EditSalesWithIdCommand, IsValid<Sale>>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditSalesWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Sale>> Handle(EditSalesWithIdCommand request, CancellationToken cancellationToken)
        {

            var validator = new EditSalesValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Sale>(new Sale(),isValid );
            }
                        
            var idList = await _context.Sales.Select(x => x.GamesToPlatforms_id).ToListAsync();
            if (idList.Contains(request.Id))
            {
                var sale = await _context.Sales.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                sale.Sales_Eu = request.Sales.Sales_Eu;
                sale.Sales_Global = request.Sales.Sales_Global;
                sale.Sales_Jp = request.Sales.Sales_Jp;
                sale.Sales_Na = request.Sales.Sales_Na;
                sale.Sales_Other = request.Sales.Sales_Other;
                sale.GamesToPlatforms_id = request.Sales.GamesToPlatforms_id;

                await _context.SaveChangesAsync();
                return new IsValid<Sale>(sale,isValid);
            }
            return new IsValid<Sale>();
        }
    }
}
