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
using VideoGameSales.Core.FIlters.validators.Platform;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core
{
    public class GetPublisherByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, IsValid<Platform>>
    {
        private readonly VideoGameSalesDbContext _context;


        public GetPublisherByIdQueryHandler(VideoGameSalesDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<IsValid<Platform>> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var platformIds = await _context.Platform.Select(x => x.Id).ToListAsync();
            if (platformIds.Contains(request.Id))
            {
                var validator = new GetPlatformValidator();
                var isValid = validator.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<Platform>(new Platform(),isValid);
                }
                var platform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return new IsValid<Platform>(platform,isValid);
            }
            return new IsValid<Platform>();
            
        }
    }
}
