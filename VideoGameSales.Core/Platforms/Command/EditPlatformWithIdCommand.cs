using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;

namespace VideoGameSales.Core.Platforms.Command
{
    public class EditPlatformWithIdCommand : IRequest<Platform>
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
