using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditGameToPublisherWithIdCommandHandler : IRequestHandler<EditGameToPublisherWithIdCommand, PublishersToGames>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameToPublisherWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<PublishersToGames> Handle(EditGameToPublisherWithIdCommand request, CancellationToken cancellationToken)
        {
            var gameToPlataform = await _context.PublishersToGames.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            gameToPlataform.Id = gameToPlataform.Id;
            gameToPlataform.Games_id = request.GameToPublisher.GameId;
            gameToPlataform.Publishers_id = request.GameToPublisher.PublisherId;
            await _context.SaveChangesAsync();
            return gameToPlataform; 
        }
    }
}
