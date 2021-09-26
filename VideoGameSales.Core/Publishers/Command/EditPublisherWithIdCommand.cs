using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Publishers.Command
{
    public class EditPublisherWithIdCommand : IRequest<IsValid<Publisher>>
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
