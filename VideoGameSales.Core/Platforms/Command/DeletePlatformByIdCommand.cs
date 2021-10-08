using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Platforms.Command
{
    public class DeletePlatformByIdCommand : IRequest<IsValid<bool>>
    {
        public int Id { get; set; }
        public DeletePlatformByIdCommand(int id)
        {
            Id = id;
        }
    }
}
