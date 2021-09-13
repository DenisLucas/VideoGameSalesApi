using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreateGameToPlatformCommandHandler : IRequestHandler<CreateGameToPlatformCommand, GamesToPlataform>
    {
        private readonly VideoGameSalesDbContext _context;
        public CreateGameToPlatformCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<GamesToPlataform> Handle(CreateGameToPlatformCommand request, CancellationToken cancellationToken)
        {
            var gameToPlatform = new GamesToPlataform
            {
                Games_id = request.GameId,
                Platform_id = request.PlatformId
            };

            await _context.GamesToPlataform.AddAsync(gameToPlatform);
            await _context.SaveChangesAsync();
            return gameToPlatform;
        }
    }
}
