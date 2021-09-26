using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoGameSales.Core.FIlters.validators.Platform;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class CreatePlatFormCommandHandler : IRequestHandler<CreatePlatformCommand, IsValid<Platform>>
    {
        private readonly VideoGameSalesDbContext _context;

        public CreatePlatFormCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IsValid<Platform>> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePlatformValidator();
            var isValid = validator.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<Platform>(new Platform(),isValid);
            }
            var platform = new Platform
            {
                Name = request.Name
            };

            await _context.Platform.AddAsync(platform);
            await _context.SaveChangesAsync();
            return new IsValid<Platform>(platform,isValid);
        }
    }
}
