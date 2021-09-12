using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Command
{
    public class DeleteGameByIdCommandHandler : IRequestHandler<DeleteGameByIdCommand, bool>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteGameByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteGameByIdCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.Id);
            _context.Games.Remove(game);
            var work = await _context.SaveChangesAsync();
            return work > 0;
        }
    }
}
