using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.GameToPlataform;
using VideoGameSales.Core.GameToPlatform.Query;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetGameToPlatformByIdQueryHandler : IRequestHandler<GetGameToPlatformByIdQuery,IsValid<GameToPlatformViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetGameToPlatformByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<GameToPlatformViewModel>> Handle(GetGameToPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var validation = new GetGameToPlatformValidator();
            var isValid = validation.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<GameToPlatformViewModel>(new GameToPlatformViewModel(),isValid);
            }
            var idList = await _context.GamesToPlataform.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
                    
                var gameToPlatform = await _context.GamesToPlataform.Where(x=> x.Id == request.Id).FirstOrDefaultAsync();
                
                var game = new GameToPlatformViewModel
                {
                    GameId = gameToPlatform.Games_id,
                    PlatformId = gameToPlatform.Platform_id,
                };
                game.GameName = await _context.Games.Where(x => x.Id == gameToPlatform.Games_id).Select(n => n.Name).FirstOrDefaultAsync();
                game.PlatformName = await _context.Platform.Where(x => x.Id == gameToPlatform.Platform_id).Select(n => n.Name).FirstOrDefaultAsync();
                return new IsValid<GameToPlatformViewModel>(new GameToPlatformViewModel
                    {
                        GameId = gameToPlatform.Games_id,
                        PlatformId = gameToPlatform.Platform_id,
                        GameName = _context.Games.Where(x => x.Id == gameToPlatform.Games_id).Select(x=>  x.Name).FirstOrDefault(),
                        PlatformName = _context.Platform.Where(x => x.Id == gameToPlatform.Platform_id).Select(x=>  x.Name).FirstOrDefault()
                    }, isValid);
            }

            return new IsValid<GameToPlatformViewModel>();
        }
    }
}
