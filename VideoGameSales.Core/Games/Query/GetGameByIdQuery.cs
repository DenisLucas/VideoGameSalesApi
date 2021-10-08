using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Games.Query
{
    public class GetGameByIdQuery : IRequest<IsValid<GameViewModel>>
    {
        public int Id { get; set; }

        public GetGameByIdQuery(int id)
        {
            Id = id;
        }
    }
}
