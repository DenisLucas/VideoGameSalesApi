using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.FIlters.validators.Game;
using VideoGameSales.Core.Games.Command;
using VideoGameSales.Core.Games.Query;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.Errors;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers.Games
{
    [ApiController]
    [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class GameController : ControllerBase
    {
        private const string _base = "api/game";
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;


        public GameController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }


        [HttpPost(_base)]
        public async Task<IActionResult> createGameAsync([FromBody] CreateGameCommand request)
        {
            
            var game = await _mediator.Send(request);
         
            if (!game.Valid.IsValid)
            {
                return BadRequest(erroResponse(game.Valid));
            }             

         
            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                return Created(uri, new Response<GameViewModel>(game.Data));
            }
            return BadRequest();
        }


        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getGameAsync(int id)
        {
            var query = new GetGameByIdQuery(id);
            var game = await _mediator.Send(query);
            
            if (game.Valid != null && !game.Valid.IsValid)
            {
                return BadRequest(erroResponse(game.Valid));
            }             

            
            if (game.Data != null) return Ok(new Response<GameViewModel>(game.Data));

            return BadRequest("The id is not valid");
        }


        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editGameAsync(int id, [FromBody] EditGameCommand request)
        {
            var command = new EditGameWithIdCommand(id,request);

            var game = await _mediator.Send(command);
            if (!game.Valid.IsValid)return BadRequest(erroResponse(game.Valid));;

            if (game != null)
            { 
                var uri = _urlHelper.GetUri(game.Id.ToString());
                return Ok(new Response<GameViewModel>(game.Data));
            }
            return BadRequest("Invalid id");
        }


        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deleteGameAsync(int id)
        {
            var command = new DeleteGameByIdCommand(id);
            var game = await _mediator.Send(command);
            if (!game.Valid.IsValid)
            {
                return BadRequest(erroResponse(game.Valid));;
            }            
            if (game.Data) return Ok();

            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }


        [HttpGet(_base + "/all")]
        public async Task<IActionResult> getAllGamesAsync([FromQuery] PaginationQuery pagination)
        {
            var query = new GetAllGamesQuery(pagination);
            var game = await _mediator.Send(query);
            
            var gamepage = new GamesPagination();
            var pageResponse = gamepage.pagination(_urlHelper,game,pagination);

            if (game != null) return Ok(pageResponse);
            return BadRequest();
        }


        private ErrorResponse erroResponse(ValidationResult erros)
        {
            var Errors = new ErrorResponse();
                foreach (var erro in erros.Errors)
                {
                    Errors.ErrorMessage.Add(new ErrorModel
                    {
                        FieldName = erro.PropertyName,
                        ErrorMessage = erro.ErrorMessage
                    });
                }
                return Errors;
        }
    }
}
