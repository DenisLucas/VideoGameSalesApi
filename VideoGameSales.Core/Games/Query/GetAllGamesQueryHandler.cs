using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core.Games.Query
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GameViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;
        public GetAllGamesQueryHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<List<GameViewModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Pagination.Page - 1) * request.Pagination.PageSize;
            return await _context.Games.OrderBy(x => x.Id).Skip(skip).Take(request.Pagination.PageSize).Select( item => new GameViewModel{
                            Ranks = item.Ranks,
                            Name = item.Name,
                            Genre = item.Genre,
                            Release_year = item.Release_year,
                            platforms = item.Platform.Select(n => n.Platform.Name).ToList(),
                            publisher = item.Publisher.Name}).ToListAsync();

        }
    }
}
