using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.Platform;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Domain.ViewModels.Platforms;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class EditPlatformWithIdCommandHandler : IRequestHandler<EditPlatformWithIdCommand, IsValid<PlatformViewModel>>
    {
        private readonly VideoGameSalesDbContext _context;

        public EditPlatformWithIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<PlatformViewModel>> Handle(EditPlatformWithIdCommand request, CancellationToken cancellationToken)
        {
            
            var platformIds = await _context.Platform.Select(x => x.Id).ToListAsync();
            if (platformIds.Contains(request.Id))
            {            
                var validation = new EditPlatformValidator();
                var isValid = validation.Validate(request);
                if (!isValid.IsValid)
                {
                    return new IsValid<PlatformViewModel>(new PlatformViewModel(),isValid);
                }
                var platform = await _context.Platform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                platform.Name = request.Platform.Name;
                await _context.SaveChangesAsync();
                return new IsValid<PlatformViewModel>(new PlatformViewModel
                {
                    Name = platform.Name
                }, isValid, platform.Id);
            }
            return new IsValid<PlatformViewModel>();
        }
    }
}
