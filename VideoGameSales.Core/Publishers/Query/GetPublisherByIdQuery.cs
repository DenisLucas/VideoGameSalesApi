using System;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;

namespace VideoGameSales.Core.Publishers.Query
{
    public class GetPublisherByIdQuery : IRequest<Publisher>
    {
        public int Id { get; set; }

        public GetPublisherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
