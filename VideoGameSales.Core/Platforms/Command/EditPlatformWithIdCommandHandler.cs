using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditPlatformWithIdCommandHandler : IRequestHandler<EditPlatformWithIdCommand, Platform>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditPlatformWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Platform> Handle(EditPlatformWithIdCommand request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            platform.Name = request.Platform.Name;
            await _context.SaveChangesAsync();
            return platform;
        }
    }
}
