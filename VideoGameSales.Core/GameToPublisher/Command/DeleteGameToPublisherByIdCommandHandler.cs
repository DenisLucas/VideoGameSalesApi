using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeleteGameToPublisherByIdCommandHandler : IRequestHandler<DeleteGameToPublisherByIdCommand, bool>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteGameToPublisherByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteGameToPublisherByIdCommand request, CancellationToken cancellationToken)
        {
            var gamesToPublisher = await _context.PublishersToGames.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            _context.PublishersToGames.Remove(gamesToPublisher);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
