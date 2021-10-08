using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Command
{
    public class EditGameWithIdCommandHandler : IRequestHandler<EditGameWithIdCommand, IsValid<GameViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
            
        }

        public async Task<IsValid<GameViewModel>> Handle(EditGameWithIdCommand request, CancellationToken cancellationToken)
        {
            var gameIds = await _context.Games.Select(x => x.Id).ToListAsync();
            if (gameIds.Contains(request.Id))
            {
                var validation = new EditGameValidator();
                var isValid = validation.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<GameViewModel>(new GameViewModel(), isValid);
                }
                var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.Id);
                game.Name = request.Game.Name;
                game.Genre = request.Game.Genre;
                game.Ranks = request.Game.Ranks;    
                game.Release_year = request.Game.Release_year;

                await _context.SaveChangesAsync();
                
                return new IsValid<GameViewModel>(new GameViewModel
            {
                Name = game.Name,
                Ranks = game.Ranks,
                Release_year = game.Release_year,
                Genre = game.Genre,
                publisher = game.Publisher.Name,
                platforms = game.Platform.Select(x => x.Platform.Name).ToList()
            }, isValid,game.Id);
            }
            return new IsValid<GameViewModel>();
        }
    }
}
