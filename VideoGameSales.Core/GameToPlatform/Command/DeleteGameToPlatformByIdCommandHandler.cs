using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeleteGameToPlatformByIdCommandHandler : IRequestHandler<DeleteGameToPlatformByIdCommand, bool>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteGameToPlatformByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteGameToPlatformByIdCommand request, CancellationToken cancellationToken)
        {
            var gamesToPlataform = await _context.GamesToPlataform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            _context.GamesToPlataform.Remove(gamesToPlataform);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
