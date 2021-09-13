using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.GameToPlatform.Query;
using VideoGameSales.Core.GameToPublisher.Query;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetGameToPublisherByIdQueryHandler : IRequestHandler<GetGameToPublisherByIdQuery,GameToPublisherViewModel>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetGameToPublisherByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<GameToPublisherViewModel> Handle(GetGameToPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var gameToPlatform = await _context.PublishersToGames.Where(x=> x.Id == request.Id).FirstOrDefaultAsync();
            
            var game = new GameToPublisherViewModel
            {
                GameId = gameToPlatform.Games_id,
                PublisherId = gameToPlatform.Publishers_id,
            };
            game.GameName = await _context.Games.Where(x => x.Id == gameToPlatform.Games_id).Select(n => n.Name).FirstOrDefaultAsync();
            game.PublisherName = await _context.Publishers.Where(x => x.Id == game.PublisherId).Select(n => n.Name).FirstOrDefaultAsync();
            return game;
        }
    }
}
