using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Command
{
    public class EditGameWithIdCommandHandler : IRequestHandler<EditGameWithIdCommand, Game>
    {
        private readonly VideoGameSalesDbContext _context;
        public EditGameWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
            
        }

        public async Task<Game> Handle(EditGameWithIdCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.Id);
            game.Name = request.Game.Name;
            game.Genre = request.Game.Genre;
            game.Ranks = request.Game.Ranks;    
            game.Release_year = request.Game.Release_year;

            await _context.SaveChangesAsync();
            return game;
        }
    }
}
