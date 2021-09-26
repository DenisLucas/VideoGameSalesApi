using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Command
{
    public class EditGameWithIdCommandHandler : IRequestHandler<EditGameWithIdCommand, IsValid<Game>>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
            
        }

        public async Task<IsValid<Game>> Handle(EditGameWithIdCommand request, CancellationToken cancellationToken)
        {
            var gameIds = await _context.Games.Select(x => x.Id).ToListAsync();
            if (gameIds.Contains(request.Id))
            {
                var validation = new EditGameValidator();
                var isValid = validation.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<Game>(new Game(), isValid);
                }
                var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.Id);
                game.Name = request.Game.Name;
                game.Genre = request.Game.Genre;
                game.Ranks = request.Game.Ranks;    
                game.Release_year = request.Game.Release_year;

                await _context.SaveChangesAsync();
                
                return new IsValid<Game>(game, isValid);
            }
            return new IsValid<Game>();
        }
    }
}
