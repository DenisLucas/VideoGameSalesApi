using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Infrastructure;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Games.Command
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand,IsValid<Game>>
    {
        private readonly VideoGameSalesDbContext _context;
        public CreateGameCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<Game>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateGameValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Game>(new Game(),isValid);
            }
            
            var game = new Game
                {
                    Name = request.Name,
                    Genre = request.Genre,
                    Ranks = request.Ranks,
                    Release_year = request.Release_year        
                };
            
            
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

            var publisherToGames = new PublishersToGames
                {
                    Games_id = game.Id,
                    Publishers_id = request.Publisher_id
                };
            await _context.PublishersToGames.AddAsync(publisherToGames);
        
            await _context.SaveChangesAsync();
            
            return new IsValid<Game>(game,isValid);
            
        }
    }
}
