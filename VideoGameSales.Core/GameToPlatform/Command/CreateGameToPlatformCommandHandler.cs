using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.FIlters.validators.GameToPlataform;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreateGameToPlatformCommandHandler : IRequestHandler<CreateGameToPlatformCommand, IsValid<GamesToPlataform>>
    {
        private readonly VideoGameSalesDbContext _context;
        public CreateGameToPlatformCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<GamesToPlataform>> Handle(CreateGameToPlatformCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateGameToPlatformValidator();
            var isValid = validation.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<GamesToPlataform>(new GamesToPlataform(),isValid);
            }
            
            var gameToPlatform = new GamesToPlataform
            {
                Games_id = request.GameId,
                Platform_id = request.PlatformId
            };

            await _context.GamesToPlataform.AddAsync(gameToPlatform);
            await _context.SaveChangesAsync();
            return new IsValid<GamesToPlataform>(gameToPlatform,isValid);
        }
    }
}
