using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;

namespace VideoGameSales.Core.Publishers.Command
{
    public class EditPublisherWithIdCommand : IRequest<Publisher>
    {
        public int Id { get; set; }
        public EditPublisherCommand Publisher { get; set; }
        public EditPublisherWithIdCommand(EditPublisherCommand publisher,int id)
        {
            Id = id;
            Publisher = publisher;
        }
    }
}
