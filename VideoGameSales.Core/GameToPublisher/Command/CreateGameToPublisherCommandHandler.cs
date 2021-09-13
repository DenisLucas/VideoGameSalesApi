using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreateGameToPublisherCommandHandler : IRequestHandler<CreateGameToPublisherCommand, PublishersToGames>
    {
        private readonly VideoGameSalesDbContext _context;
        public CreateGameToPublisherCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<PublishersToGames> Handle(CreateGameToPublisherCommand request, CancellationToken cancellationToken)
        {
            var gameToPublisher = new PublishersToGames
            {
                Games_id = request.GameId,
                Publishers_id = request.PublisherId
            };

            await _context.PublishersToGames.AddAsync(gameToPublisher);
            await _context.SaveChangesAsync();
            return gameToPublisher;
        }
    }
}
