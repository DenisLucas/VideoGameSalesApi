using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.FIlters.validators.GameToPublisher;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreateGameToPublisherCommandHandler : IRequestHandler<CreateGameToPublisherCommand, IsValid<PublishersToGames>>
    {
        private readonly VideoGameSalesDbContext _context;
        public CreateGameToPublisherCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<PublishersToGames>> Handle(CreateGameToPublisherCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateGameToPublisherValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<PublishersToGames>(new PublishersToGames(),isValid);
            }
            
            var gameToPublisher = new PublishersToGames
            {
                Games_id = request.GameId,
                Publishers_id = request.PublisherId
            };

            await _context.PublishersToGames.AddAsync(gameToPublisher);
            await _context.SaveChangesAsync();
            return new IsValid<PublishersToGames>(gameToPublisher,isValid);
        }
    }
}
