using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;

namespace VideoGameSales.Core.Platforms.Command
{
    public class CreatePlatformCommand : IRequest<Platform>
    {
        public string Name { get; set; }
    }
}
