using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Query
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, IsValid<GameViewModel>>
    {
        public readonly VideoGameSalesDbContext _context;
        public readonly IMapper _mapper;

        public GetGameByIdQueryHandler(VideoGameSalesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IsValid<GameViewModel>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
           
                var validation = new GetGameByIdValidator();
                var isValid = validation.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<GameViewModel>(new GameViewModel(),isValid);
                }
                var gameIds = await _context.Games.Select(x => x.Id).ToListAsync();
                if (gameIds.Contains(request.Id))
                {
                var game = await _context.Games.Where(x => x.Id == request.Id).Select(game => new GameViewModel
                {
                    Name = game.Name,
                    Ranks = game.Ranks,
                    Release_year = game.Release_year,
                    Genre = game.Genre,
                    platforms = game.Platform.Select(n => n.Platform.Name).ToList(),
                }).FirstOrDefaultAsync();


                var publishersToGames = await _context.PublishersToGames.Where(x => x.Games_id == request.Id).FirstOrDefaultAsync();
                var publisher = await _context.Publishers.Where(x => x.Id == publishersToGames.Publishers_id).FirstOrDefaultAsync();
                game.publisher = publisher.Name;
                return new IsValid<GameViewModel>(game, isValid);
            }
            return new IsValid<GameViewModel>();
        }
    }
}
