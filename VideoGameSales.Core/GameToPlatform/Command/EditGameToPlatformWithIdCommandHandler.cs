using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.GameToPlataform;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditGameToPlatformWithIdCommandHandler : IRequestHandler<EditGameToPlatformWithIdCommand, IsValid<GameToPlatformViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameToPlatformWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<GameToPlatformViewModel>> Handle(EditGameToPlatformWithIdCommand request, CancellationToken cancellationToken)
        {
            var validation = new EditGameToPlatformValidator();
            var isValid = validation.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<GameToPlatformViewModel>(new GameToPlatformViewModel(),isValid);
            }
            var idList = await _context.GamesToPlataform.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
            
                var gameToPlatform = await _context.GamesToPlataform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                gameToPlatform.Id = gameToPlatform.Id;
                gameToPlatform.Games_id = request.GameToPlatform.GameId;
                gameToPlatform.Platform_id = request.GameToPlatform.PlatformId;
                await _context.SaveChangesAsync();
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
