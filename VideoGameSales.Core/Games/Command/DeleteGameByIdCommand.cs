using System;

namespace VideoGameSales.Core.Games.Command
{
    public class DeleteGameByIdCommand
    {
        public int Id { get; set; }

        public DeleteGameByIdCommand(int id)
        {
            Id = id;
        }

    }
}
