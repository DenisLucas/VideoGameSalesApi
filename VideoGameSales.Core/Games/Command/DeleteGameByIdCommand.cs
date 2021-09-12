using System;
using MediatR;

namespace VideoGameSales.Core.Games.Command
{
    public class DeleteGameByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteGameByIdCommand(int id)
        {
            Id = id;
        }

    }
}
