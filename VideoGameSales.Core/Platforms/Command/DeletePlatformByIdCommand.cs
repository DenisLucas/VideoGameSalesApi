using System;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;

namespace VideoGameSales.Core.Platforms.Command
{
    public class DeletePlatformByIdCommand : IRequest<Platform>
    {
        public int Id { get; set; }
        public DeletePlatformByIdCommand(int id)
        {
            Id = id;
        }
    }
}
