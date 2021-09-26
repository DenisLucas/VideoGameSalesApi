using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Core.FIlters.validators.GameToPlataform;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Core
{
    public class DeleteGameToPlatformByIdCommandHandler : IRequestHandler<DeleteGameToPlatformByIdCommand, IsValid<bool>>
    {
        private readonly VideoGameSalesDbContext _context;
        public DeleteGameToPlatformByIdCommandHandler(VideoGameSalesDbContext context)
        {
            _context = context;
        }
        public async Task<IsValid<bool>> Handle(DeleteGameToPlatformByIdCommand request, CancellationToken cancellationToken)
        {
            var validation = new DeleteGameToPlatformValidator();
            var isValid = validation.Validate(request);
            if (!isValid.IsValid)
            {
                return new IsValid<bool>(false,isValid);
            }
            var idList = await _context.GamesToPlataform.Select(x => x.Id).ToListAsync();
            if (idList.Contains(request.Id))
            {
            var gamesToPlataform = await _context.GamesToPlataform.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            _context.GamesToPlataform.Remove(gamesToPlataform);
            var result = await _context.SaveChangesAsync();
            return new IsValid<bool>(result > 0,isValid);
            }
            return new IsValid<bool>();
        }
    }
}
