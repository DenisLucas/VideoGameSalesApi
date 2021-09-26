using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Core.GameToPlatform.Query;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.Errors;
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
            if (!gameToPlatform.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPlatform.Valid));
            } 
            if (gameToPlatform.Data != null)
            { 
            
                var uri = _urlHelper.GetUri(gameToPlatform.Data.Id.ToString());
                var response = _mapper.Map<GameToPlatformViewModel>(gameToPlatform);
                return Created(uri, new Response<GameToPlatformViewModel>(response));
            }

            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getGameToPlatformAsync(int id)
        {
          
            var query = new GetGameToPlatformByIdQuery(id);
            var gameToPlatform = await _mediator.Send(query);
            if (!gameToPlatform.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPlatform.Valid));
            }
            if (gameToPlatform.Data != null)
            { 
                return Ok(new Response<GameToPlatformViewModel>(gameToPlatform.Data));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editGameToPlatformAsync(int id, [FromBody] EditGameToPlatformCommand request)
        {
            var command = new EditGameToPlatformWithIdCommand(id,request);
            var gameToPlatform = await _mediator.Send(command);
            if (!gameToPlatform.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPlatform.Valid));
            }  
            if (gameToPlatform.Data != null)
            { 
                return Ok(new Response<GameToPlatformViewModel>(gameToPlatform.Data));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deleteGameToPlatformAsync(int id)
        {
            var query = new DeleteGameToPlatformByIdCommand(id);
            var gameToPlatform = await _mediator.Send(query);
            if (!gameToPlatform.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPlatform.Valid));
            }  
            if (gameToPlatform.Data)
            { 
                return Ok();
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
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
