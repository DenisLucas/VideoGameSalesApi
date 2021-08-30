using System;
using MediatR;
using VideoGameSales.Domain.Entities.Games;

namespace VideoGameSales.Core.Games.Query
{
    public class GetGameByIdQuery : IRequest<Game>
    {
        public int Id { get; set; }

        public GetGameByIdQuery(int id)
        {
            Id = id;
        }
    }
}
