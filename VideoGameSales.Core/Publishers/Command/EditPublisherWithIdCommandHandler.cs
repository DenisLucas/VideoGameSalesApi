using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Publisher;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditPublisherWithIdCommandHandler : IRequestHandler<EditPublisherWithIdCommand, IsValid<Publisher>>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditPublisherWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Publisher>> Handle(EditPublisherWithIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new EditPublisherValidator();
            var isValid = validator.Validate(request);
            
            if (!isValid.IsValid)
            {
                return new IsValid<Publisher>(new Publisher(),isValid);
            }

            var IdList = await _context.Publishers.Select(x => x.Id).ToListAsync();
            if (IdList.Contains(request.Id))
            {
                var publisher = await _context.Publishers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                publisher.Name = request.Publisher.Name;
                await _context.SaveChangesAsync();
                return new IsValid<Publisher>(publisher, isValid);
            }
            return new IsValid<Publisher>();
        }
    }
}
