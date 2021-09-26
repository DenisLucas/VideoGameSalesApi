using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Platform;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeletePlatformByIdCommandHandler : IRequestHandler<DeletePlatformByIdCommand,IsValid<bool>>
    {
        private readonly VideoGameSalesDbContext _context;

        public DeletePlatformByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<bool>> Handle(DeletePlatformByIdCommand request, CancellationToken cancellationToken)
        {
            var platformIds = await _context.Platform.Select(x => x.Id).ToListAsync();
            if (platformIds.Contains(request.Id))
            {
                var validator = new DeletePlatformValidator();
                var isValid = validator.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<bool>(false, isValid);
                }
                var plataform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                _context.Platform.Remove(plataform);
                var result = await _context.SaveChangesAsync();
                return new IsValid<bool>(result > 0,isValid);
            }
            return new IsValid<bool>();
        }
    }
}
