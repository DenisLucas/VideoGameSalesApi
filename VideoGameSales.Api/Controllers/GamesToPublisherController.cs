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
    public class GamesToPublisherController : ControllerBase
    {
        public const string _base = "api/gametopublisher";
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public GamesToPublisherController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost(_base)]
        public async Task<IActionResult> createGameToPublisherAsync([FromBody] CreateGameToPublisherCommand request)
        {
            var gameToPublisher = await _mediator.Send(request);
            if (gameToPublisher != null)
            { 
                var uri = _urlHelper.GetUri(gameToPublisher.Id.ToString());
                var response = _mapper.Map<GameToPublisherViewModel>(gameToPublisher);
                return Created(uri, new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest();
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getGameToPublisherAsync(int id)
        {
            var query = new GetGameToPublisherByIdQuery(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<GameToPublisherViewModel>(game);
                return Ok(new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editGameToPublisherAsync(int id, [FromBody] EditGameToPublisherCommand request)
        {
            var command = new EditGameToPublisherWithIdCommand(id,request);
            var game = await _mediator.Send(command);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<GameToPublisherViewModel>(game);
                return Ok(new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest();
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deleteGameToPublisherAsync(int id)
        {
            var query = new DeleteGameToPublisherByIdCommand(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var response = _mapper.Map<GameToPublisherViewModel>(game);
                return Ok(new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest();
        }
    }
}
