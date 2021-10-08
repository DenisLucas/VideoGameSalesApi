using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Publisher;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeletePublisherByIdCommandHandler : IRequestHandler<DeletePublisherByIdCommand,IsValid<bool>>
    {
        private readonly VideoGameSalesDbContext _context;

        public DeletePublisherByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<bool>> Handle(DeletePublisherByIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePublisherValidator();
            var isValid = validator.Validate(request);
            
            if (!isValid.IsValid)
            {
                return new IsValid<bool>(false,isValid);
            }
            var IdList = await _context.Publishers.Select(x => x.Id).ToListAsync();
            if (IdList.Contains(request.Id))
            {
                var publisher = await _context.Publishers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                _context.Publishers.Remove(publisher);
                var result = await _context.SaveChangesAsync();
                return new IsValid<bool>(result > 0, isValid);
            }
            return new IsValid<bool>();
        }
    }
}
