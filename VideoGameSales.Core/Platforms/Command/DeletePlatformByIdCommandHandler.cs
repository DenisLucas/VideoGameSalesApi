using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeletePlatformByIdCommandHandler : IRequestHandler<DeletePlatformByIdCommand,bool>
    {
        private readonly VideoGameSalesDbContext _context;

        public DeletePlatformByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePlatformByIdCommand request, CancellationToken cancellationToken)
        {
            var plataform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            _context.Platform.Remove(plataform);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
