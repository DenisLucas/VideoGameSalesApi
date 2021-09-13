using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeletePublisherByIdCommandHandler : IRequestHandler<DeletePublisherByIdCommand,bool>
    {
        private readonly VideoGameSalesDbContext _context;

        public DeletePublisherByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePublisherByIdCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _context.Publishers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            _context.Publishers.Remove(publisher);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
