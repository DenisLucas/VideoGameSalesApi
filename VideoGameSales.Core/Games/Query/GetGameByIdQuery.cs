using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Core.Games.Query
{
    public class GetGameByIdQuery : IRequest<GameViewModel>
    {
        public int Id { get; set; }

        public GetGameByIdQuery(int id)
        {
            Id = id;
        }
    }
}
