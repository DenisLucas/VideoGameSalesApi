using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Games;
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
                return Created(uri, game);
            }
            return BadRequest();
                
        }
        
    }
}
