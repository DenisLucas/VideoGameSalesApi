using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Platforms.Query;
using AutoMapper;
using VideoGameSales.Domain.ViewModels.Platforms;
using VideoGameSales.Infrastructure;
using VideoGameSales.Domain.Entities.Platforms;

namespace VideoGameSales.Core
{
    public class GetPublisherByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, Platform>
    {
        private readonly VideoGameSalesDbContext _context;
        private readonly IMapper _mapper;

        public GetPublisherByIdQueryHandler(VideoGameSalesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Platform> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            
            return platform;
        }
    }
}
