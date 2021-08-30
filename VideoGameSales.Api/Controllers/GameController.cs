using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Games.Command;
using VideoGameSales.Core.Games.Query;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers.Games
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public GameController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost]
        public async Task<IActionResult> createGameAsync([FromBody] CreateGameCommand request)
        {
            var game = await _mediator.Send(request);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<GameViewModel>(game);
                return Created(uri, new Response<GameViewModel>(response));
            }
            return BadRequest();
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> getGameAsync(int id)
        {
            var query = new GetGameByIdQuery(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<GameViewModel>(game);
                return Ok(new Response<GameViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> editGameAsync(int id, [FromBody] EditGameCommand request)
        {
            var command = new EditGameWithIdCommand(id,request);
            var game = await _mediator.Send(command);
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                var response = _mapper.Map<GameViewModel>(game);
                return Ok(new Response<GameViewModel>(response));
            }
            return BadRequest();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> deleteGameAsync(int id)
        {
            var query = new DeleteGameByIdCommand(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var response = _mapper.Map<GameViewModel>(game);
                return Ok(new Response<GameViewModel>(response));
            }
            return BadRequest();
        }


    }
}
