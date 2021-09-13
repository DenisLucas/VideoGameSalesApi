using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, Publisher>
    {
        private readonly VideoGameSalesDbContext _context;

        public CreatePublisherCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = new Publisher
            {
                Name = request.Name
            };

            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }
    }
}
