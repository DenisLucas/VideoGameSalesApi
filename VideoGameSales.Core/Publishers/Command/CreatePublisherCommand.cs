using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;

namespace VideoGameSales.Core.Publishers.Command
{
    public class CreatePublisherCommand : IRequest<Publisher>
    {
        public string Name { get; set; }
    }
}
