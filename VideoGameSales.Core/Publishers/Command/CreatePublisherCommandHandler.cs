using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.FIlters.validators.Publisher;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, IsValid<Publisher>>
    {
        private readonly VideoGameSalesDbContext _context;

        public CreatePublisherCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Publisher>> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePublisherValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Publisher>(new Publisher(),isValid);
            }
            var publisher = new Publisher
            {
                Name = request.Name
            };

            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return new IsValid<Publisher>(publisher,isValid);
        }
    }
}
