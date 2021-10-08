using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Publishers.Command
{
    public class CreatePublisherCommand : IRequest<IsValid<Publisher>>
    {
        public string Name { get; set; }
    }
}
