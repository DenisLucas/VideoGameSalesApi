using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreatePlatFormCommandHandler : IRequestHandler<CreatePlatformCommand, Platform>
    {
        private readonly VideoGameSalesDbContext _context;

        public CreatePlatFormCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Platform> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = request.Name
            };

            await _context.Platform.AddAsync(platform);
            await _context.SaveChangesAsync();
            return platform;
        }
    }
}
