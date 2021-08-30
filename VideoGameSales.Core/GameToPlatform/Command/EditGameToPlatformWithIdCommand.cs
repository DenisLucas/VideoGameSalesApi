using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class EditGameToPlatformWithIdCommand : IRequest<GamesToPlatform>
    {
        public int Id { get; set; }
        public EditGameToPlatformCommand GameToPlatform { get; set; }

        public EditGameToPlatformWithIdCommand(int id, EditGameToPlatformCommand gameToPlatform)
        {
            Id = id;
            GameToPlatform = gameToPlatform;
        }
    }
}
