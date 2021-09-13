using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Connectors;

namespace VideoGameSales.Core.GameToPlatform.Query
{
    public class GetGameToPlatformByIdQuery : IRequest<GameToPlatformViewModel>
    {

        public int Id { get; set; }

        public GetGameToPlatformByIdQuery(int id)
        {
            Id = id;
        }
    }
}
