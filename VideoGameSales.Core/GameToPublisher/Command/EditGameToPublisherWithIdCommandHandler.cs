using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.GameToPublisher;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditGameToPublisherWithIdCommandHandler : IRequestHandler<EditGameToPublisherWithIdCommand, IsValid<PublishersToGames>>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameToPublisherWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<PublishersToGames>> Handle(EditGameToPublisherWithIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new EditGameToPublisherValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<PublishersToGames>(new PublishersToGames(), isValid);
            }
            var idList = await _context.PublishersToGames.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
                var gameToPublisher = await _context.PublishersToGames.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                gameToPublisher.Id = gameToPublisher.Id;
                gameToPublisher.Games_id = request.GameToPublisher.GameId;
                gameToPublisher.Publishers_id = request.GameToPublisher.PublisherId;
                await _context.SaveChangesAsync();
                return new IsValid<PublishersToGames>(gameToPublisher, isValid);
            }
            return new IsValid<PublishersToGames>();
        }
    }
}
