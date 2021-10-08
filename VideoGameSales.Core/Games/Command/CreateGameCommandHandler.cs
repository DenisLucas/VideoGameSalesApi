using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Infrastructure;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.ViewModels.IsValid;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Core.Games.Command
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand,IsValid<GameViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;
        public CreateGameCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<GameViewModel>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateGameValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<GameViewModel>(new GameViewModel(),isValid);
            }
            
            var game = new Game
                {
                    Name = request.Name,
                    Genre = request.Genre,
                    Ranks = request.Ranks,
                    Release_year = request.Release_year    
                };
            game.Publisher = await _context.Publishers.Where(x=> x.Id == request.Publisher_id).FirstOrDefaultAsync();
            
            var gameDb = await _context.Games.AddAsync(game);
            
            await _context.SaveChangesAsync();
            foreach (var id in request.Platform_Id)
            {
                var gamesToPlataform = new GamesToPlataform
                {
                    Games_id = game.Id,
                    Platform_id = id
                
                };
                await _context.GamesToPlataform.AddAsync(gamesToPlataform);
        
            }
        
            await _context.SaveChangesAsync();
            
            return new IsValid<GameViewModel>(new GameViewModel
            {
                Name = game.Name,
                Ranks = game.Ranks,
                Release_year = game.Release_year,
                Genre = game.Genre,
                publisher = game.Publisher.Name,
                platforms = game.Platform.Select(x => x.Platform.Name).ToList()
            }
            ,isValid, game.Id);
            
        }
    }
}
