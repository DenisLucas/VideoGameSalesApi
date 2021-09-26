using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.GameToPublisher;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeleteGameToPublisherByIdCommandHandler : IRequestHandler<DeleteGameToPublisherByIdCommand,IsValid<bool>>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteGameToPublisherByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<bool>> Handle(DeleteGameToPublisherByIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteGameToPublisherValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<bool>(false, isValid);
            }
            var idList = await _context.PublishersToGames.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
                var gamesToPublisher = await _context.PublishersToGames.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                _context.PublishersToGames.Remove(gamesToPublisher);
                var result = await _context.SaveChangesAsync();
                return new IsValid<bool>(result > 0,isValid);
            }
            return new IsValid<bool>();
        }
    }
}
