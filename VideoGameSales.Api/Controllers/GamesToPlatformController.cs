using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Core.GameToPlatform.Query;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.ViewModels.Connectors;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{
    [ApiController]
    public class GamesToPlatformController : ControllerBase
    {
        public const string _base = "api/gametoplatform";
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public GamesToPlatformController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost(_base)]
        public async Task<IActionResult> createGameToPlatformAsync([FromBody] CreateGameToPlatformCommand request)
        {
            var gameToPlatform = await _mediator.Send(request);
            if (gameToPlatform != null)
            { 
                var uri = _urlHelper.GetUri(gameToPlatform.Id.ToString());
                var response = _mapper.Map<GameToPlatformViewModel>(gameToPlatform);
                return Created(uri, new Response<GameToPlatformViewModel>(response));
            }
            return BadRequest();
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getGameToPlatformAsync(int id)
        {
            var query = new GetGameToPlatformByIdQuery(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var response = _mapper.Map<GameToPlatformViewModel>(game);
                return Ok(new Response<GameToPlatformViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editGameToPlatformAsync(int id, [FromBody] EditGameToPlatformCommand request)
        {
            var command = new EditGameToPlatformWithIdCommand(id,request);
            var game = await _mediator.Send(command);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<GameToPlatformViewModel>(game);
                return Ok(new Response<GameToPlatformViewModel>(response));
            }
            return BadRequest();
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deleteGameToPlatformAsync(int id)
        {
            var query = new DeleteGameToPlatformByIdCommand(id);
            var game = await _mediator.Send(query);
            if (game)
            { 
                return Ok();
            }
            return BadRequest();
        }
    }
}
