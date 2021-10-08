using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Publisher;
using VideoGameSales.Core.Publishers.Query;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetPublishersByIdQueryHandler : IRequestHandler<GetPublisherByIdQuery, IsValid<Publisher>>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetPublishersByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Publisher>> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPublisherValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Publisher>(new Publisher(),isValid);
            }
            var IdList = await _context.Publishers.Select(x => x.Id).ToListAsync();
            if (IdList.Contains(request.Id))
            {
                return new IsValid<Publisher>(await _context.Publishers.Where(x => x.Id == request.Id).FirstOrDefaultAsync(),isValid);
            }
            return new IsValid<Publisher>();
        }
    }
}
