using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Query
{
    public class GetGameToPlatformByIdQuery : IRequest<GamesToPlataform>
    {

        public int Id { get; set; }

        public GetGameToPlatformByIdQuery(int id)
        {
            Id = id;
        }
    }
}
