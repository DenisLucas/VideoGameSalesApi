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
    public class EditGameToPlatformWithIdCommandHandler : IRequestHandler<EditGameToPlatformWithIdCommand, GamesToPlataform>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameToPlatformWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<GamesToPlataform> Handle(EditGameToPlatformWithIdCommand request, CancellationToken cancellationToken)
        {
            var gameToPlataform = await _context.GamesToPlataform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            gameToPlataform.Id = gameToPlataform.Id;
            gameToPlataform.Games_id = request.GameToPlatform.GameId;
            gameToPlataform.Platform_id = request.GameToPlatform.PlatformId;
            await _context.SaveChangesAsync();
            return gameToPlataform; 
        }
    }
}
