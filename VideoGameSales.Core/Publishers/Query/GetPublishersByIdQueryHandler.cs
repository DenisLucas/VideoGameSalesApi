using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Publishers.Query;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetPublishersByIdQueryHandler : IRequestHandler<GetPublisherByIdQuery, Publisher>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetPublishersByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Publishers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
