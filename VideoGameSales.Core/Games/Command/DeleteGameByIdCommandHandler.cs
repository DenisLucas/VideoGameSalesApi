using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Command
{
    public class DeleteGameByIdCommandHandler : IRequestHandler<DeleteGameByIdCommand, IsValid<bool>>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteGameByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<bool>> Handle(DeleteGameByIdCommand request, CancellationToken cancellationToken)
        {
            var gameIds = await _context.Games.Select(x => x.Id).ToListAsync();
            if (gameIds.Contains(request.Id))
            {
                var validation = new DeleteGameValidator();
                var isValid = validation.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<bool>(false, isValid);
                }  
                var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.Id);
                _context.Games.Remove(game);
                var work = await _context.SaveChangesAsync();
                return new IsValid<bool>(work > 0,isValid);
            }
            return new IsValid<bool>();
        }
    }
}
