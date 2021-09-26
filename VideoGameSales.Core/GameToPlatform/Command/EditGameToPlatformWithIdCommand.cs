using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class EditGameToPlatformWithIdCommand : IRequest<IsValid<GameToPlatformViewModel>>
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
