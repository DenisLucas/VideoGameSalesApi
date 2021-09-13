using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.GameToPlatform.Query;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetGameToPlatformByIdQueryHandler : IRequestHandler<GetGameToPlatformByIdQuery,GameToPlatformViewModel>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetGameToPlatformByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<GameToPlatformViewModel> Handle(GetGameToPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var gameToPlatform = await _context.GamesToPlataform.Where(x=> x.Id == request.Id).FirstOrDefaultAsync();
            
            var game = new GameToPlatformViewModel
            {
                GameId = gameToPlatform.Games_id,
                PlatformId = gameToPlatform.Platform_id,
            };
            game.GameName = await _context.Games.Where(x => x.Id == gameToPlatform.Games_id).Select(n => n.Name).FirstOrDefaultAsync();
            game.PlatformName = await _context.Platform.Where(x => x.Id == gameToPlatform.Platform_id).Select(n => n.Name).FirstOrDefaultAsync();
            return game;
        }
    }
}
