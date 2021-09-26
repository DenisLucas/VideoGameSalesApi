using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.FIlters.validators.Sales;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Sales.Command
{
    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommand, IsValid<Sale>>
    {
        private readonly VideoGameSalesDbContext _context;

        public CreateSalesCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Sale>> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSalesValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Sale>(new Sale(),isValid );
            }
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

            return new IsValid<Sale>(sale, isValid);
        }
    }
}
