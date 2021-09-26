using System;
using MediatR;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Games.Command
{
    public class DeleteGameByIdCommand : IRequest<IsValid<bool>>
    {
        public int Id { get; set; }

        public DeleteGameByIdCommand(int id)
        {
            Id = id;
        }

    }
}
