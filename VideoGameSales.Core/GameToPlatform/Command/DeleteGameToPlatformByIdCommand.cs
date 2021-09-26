using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class DeleteGameToPlatformByIdCommand : IRequest<IsValid<bool>>
    {

        public int Id { get; set; }

        public DeleteGameToPlatformByIdCommand(int id)
        {
            Id = id;
        }
    }
}
