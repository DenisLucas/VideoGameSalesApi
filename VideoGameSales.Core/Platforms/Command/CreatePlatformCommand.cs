using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Platforms.Command
{
    public class CreatePlatformCommand : IRequest<IsValid<Platform>>
    {
        public string Name { get; set; }
    }
}
