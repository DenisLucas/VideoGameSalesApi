using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Platforms.Query;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetPublisherByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, Platform>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetPublisherByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Platform> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
