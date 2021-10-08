using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Sales;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeleteSalesByIdCommandHandler : IRequestHandler<DeleteSalesByIdCommand, IsValid<bool>>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteSalesByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<bool>> Handle(DeleteSalesByIdCommand request, CancellationToken cancellationToken)
        {

            var validator = new DeleteSalesValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<bool>(false,isValid );
            }
            var idList = await _context.Sales.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
                var sale = await _context.Sales.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                _context.Sales.Remove(sale);
                var result = await _context.SaveChangesAsync();
                return new IsValid<bool>(result > 0,isValid);
            }
            return new IsValid<bool>();
        }
    }
}
