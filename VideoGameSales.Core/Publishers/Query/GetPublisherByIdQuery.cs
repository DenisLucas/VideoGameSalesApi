using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;

namespace VideoGameSales.Core.Publishers.Query
{
    public class GetPublisherByIdQuery : IRequest<IsValid<Publisher>>
    {
        public int Id { get; set; }

        public GetPublisherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
