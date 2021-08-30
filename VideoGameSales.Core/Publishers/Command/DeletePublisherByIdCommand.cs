using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;

namespace VideoGameSales.Core.Publishers.Command
{
    public class DeletePublisherByIdCommand : IRequest<Publisher>
    {

        public int Id { get; set; }
        public DeletePublisherByIdCommand(int id)
        {
            Id = id;
        }
    }
}
