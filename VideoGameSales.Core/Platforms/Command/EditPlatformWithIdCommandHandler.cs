using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Platform;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditPlatformWithIdCommandHandler : IRequestHandler<EditPlatformWithIdCommand, IsValid<Platform>>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditPlatformWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Platform>> Handle(EditPlatformWithIdCommand request, CancellationToken cancellationToken)
        {
            
            var platformIds = await _context.Platform.Select(x => x.Id).ToListAsync();
            if (platformIds.Contains(request.Id))
            {            
                var validation = new EditPlatformValidator();
                var isValid = validation.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<Platform>(new Platform(),isValid);
                }
                var platform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                platform.Name = request.Platform.Name;
                await _context.SaveChangesAsync();
                return new IsValid<Platform>(platform, isValid);
            }
            return new IsValid<Platform>();
        }
    }
}
