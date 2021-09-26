using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.GameToPublisher;
using VideoGameSales.Core.GameToPublisher.Query;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class GetGameToPublisherByIdQueryHandler : IRequestHandler<GetGameToPublisherByIdQuery,IsValid<GameToPublisherViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;

        public GetGameToPublisherByIdQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<GameToPublisherViewModel>> Handle(GetGameToPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetGameToPublisherValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<GameToPublisherViewModel>(new GameToPublisherViewModel(),isValid);
            }
            var idList = await _context.PublishersToGames.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {

                var gameToPub = await _context.PublishersToGames.Where(x=> x.Id == request.Id).FirstOrDefaultAsync();
                
                var gameToPublisher = new GameToPublisherViewModel
                {
                    GameId = gameToPub.Games_id,
                    PublisherId = gameToPub.Publishers_id,
                };
                gameToPublisher.GameName = await _context.Games.Where(x => x.Id == gameToPub.Games_id).Select(n => n.Name).FirstOrDefaultAsync();
                gameToPublisher.PublisherName = await _context.Publishers.Where(x => x.Id == gameToPublisher.PublisherId).Select(n => n.Name).FirstOrDefaultAsync();
                return new IsValid<GameToPublisherViewModel>(gameToPublisher,isValid);
            }
            return new IsValid<GameToPublisherViewModel>();
        }
    }
}
