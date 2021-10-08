using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Domain.ViewModels.Platforms;

namespace VideoGameSales.Core.Platforms.Command
{
    public class CreatePlatformCommand : IRequest<IsValid<PlatformViewModel>>
    {
        public string Name { get; set; }
    }
}
