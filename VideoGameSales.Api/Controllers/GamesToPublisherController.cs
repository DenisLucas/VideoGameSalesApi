using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Core.GameToPublisher.Query;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.Errors;
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
            if (!gameToPublisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPublisher.Valid));;
            }            
            if (gameToPublisher != null)
            { 
                var uri = _urlHelper.GetUri(gameToPublisher.Data.Id.ToString());
                var response = _mapper.Map<GameToPublisherViewModel>(gameToPublisher);
                return Created(uri, new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getGameToPublisherAsync(int id)
        {
            var query = new GetGameToPublisherByIdQuery(id);
            var gameToPublisher = await _mediator.Send(query);
            if (!gameToPublisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPublisher.Valid));
            }            
            if (gameToPublisher != null)
            { 
                var response = _mapper.Map<GameToPublisherViewModel>(gameToPublisher);
                return Ok(new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editGameToPublisherAsync(int id, [FromBody] EditGameToPublisherCommand request)
        {
            var command = new EditGameToPublisherWithIdCommand(id,request);
            var gameToPublisher = await _mediator.Send(command);
            if (!gameToPublisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPublisher.Valid));;
            }            
            if (gameToPublisher != null)
            { 
                var uri = _urlHelper.GetUri(gameToPublisher.Data.Id.ToString());
                var response = _mapper.Map<GameToPublisherViewModel>(gameToPublisher.Data);
                return Ok(new Response<GameToPublisherViewModel>(response));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deleteGameToPublisherAsync(int id)
        {
            var query = new DeleteGameToPublisherByIdCommand(id);
            var gameToPublisher = await _mediator.Send(query);
            if (!gameToPublisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(gameToPublisher.Valid));;
            }            
            if (gameToPublisher.Data)
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
