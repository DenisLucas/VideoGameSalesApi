using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Publishers.Command
{
    public class DeletePublisherByIdCommand : IRequest<IsValid<bool>>
    {

        public int Id { get; set; }
        public DeletePublisherByIdCommand(int id)
        {
            Id = id;
        }
    }
}
