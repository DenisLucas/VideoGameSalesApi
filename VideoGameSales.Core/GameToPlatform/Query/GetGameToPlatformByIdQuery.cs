using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPlatform.Query
{
    public class GetGameToPlatformByIdQuery : IRequest<IsValid<GameToPlatformViewModel>>
    {

        public int Id { get; set; }

        public GetGameToPlatformByIdQuery(int id)
        {
            Id = id;
        }
    }
}
