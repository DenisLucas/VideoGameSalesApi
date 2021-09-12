using System;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;

namespace VideoGameSales.Core.GameToPlatform.Command
{
    public class DeleteGameToPlatformByIdCommand : IRequest<GamesToPlataform>
    {

        public int Id { get; set; }

        public DeleteGameToPlatformByIdCommand(int id)
        {
            Id = id;
        }
    }
}
