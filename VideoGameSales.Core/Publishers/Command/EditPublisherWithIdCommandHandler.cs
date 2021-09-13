using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditPublisherWithIdCommandHandler : IRequestHandler<EditPublisherWithIdCommand, Publisher>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditPublisherWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Handle(EditPublisherWithIdCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _context.Publishers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            publisher.Name = request.Publisher.Name;
            await _context.SaveChangesAsync();
            return publisher;
        }
    }
}
