using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Core.Platforms.Query;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Domain.ViewModels.Platforms;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public PlatformController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost]
        public async Task<IActionResult> createPlatformAsync([FromBody] CreatePlatformCommand request)
        {
            var platform = await _mediator.Send(request);
            if (platform != null)
            { 
                var uri = _urlHelper.GetUri(platform.Id.ToString());
                var response = _mapper.Map<PlatformViewModel>(platform);
                return Created(uri, new Response<PlatformViewModel>(response));
            }
            return BadRequest();
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> getPlatformAsync(int id)
        {
            var query = new GetPlatformByIdQuery(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<PlatformViewModel>(game);
                return Ok(new Response<PlatformViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> editPlatformAsync(int id, [FromBody] EditPlatformCommand request)
        {
            var command = new EditPlatformWithIdCommand(id,request);
            var game = await _mediator.Send(command);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<PlatformViewModel>(game);
                return Ok(new Response<PlatformViewModel>(response));
            }
            return BadRequest();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> deletePlatformAsync(int id)
        {
            var query = new DeletePlatformByIdCommand(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var response = _mapper.Map<PlatformViewModel>(game);
                return Ok(new Response<PlatformViewModel>(response));
            }
            return BadRequest();
        }
    }
}
