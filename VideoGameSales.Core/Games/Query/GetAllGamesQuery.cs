using System;
using System.Collections.Generic;
using MediatR;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Core.Games.Query
{
    public class GetAllGamesQuery : IRequest<List<GameViewModel>>
    {
        public PaginationQuery Pagination { get; set; }

        public GetAllGamesQuery(PaginationQuery pagination)
        {
            Pagination = pagination;
        }
    }
}
