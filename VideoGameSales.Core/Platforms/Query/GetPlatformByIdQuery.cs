using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Domain.ViewModels.Platforms;

namespace VideoGameSales.Core.Platforms.Query
{
    public class GetPlatformByIdQuery : IRequest<IsValid<PlatformViewModel>>
    {
        public int Id { get; set; }
        public GetPlatformByIdQuery(int id)
        {
            Id = id;
        }
    }
}
