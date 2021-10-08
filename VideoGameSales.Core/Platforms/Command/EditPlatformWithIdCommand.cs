using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Domain.ViewModels.Platforms;

namespace VideoGameSales.Core.Platforms.Command
{
    public class EditPlatformWithIdCommand : IRequest<IsValid<PlatformViewModel>>
    {
        public int Id { get; set; }
        public EditPlatformCommand Platform { get; set; }
        public EditPlatformWithIdCommand(int id, EditPlatformCommand platform)
        {
            Id = id;
            Platform = platform;
        }
    }
}
