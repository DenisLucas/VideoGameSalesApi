using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Core.Publishers.Query;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.Errors;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{
    [ApiController]
    [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class PublisherController : ControllerBase
    {
        private const string _base = "api/publisher"; 
        
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public PublisherController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost(_base)]
        public async Task<IActionResult> createPublisherAsync([FromBody] CreatePublisherCommand request)
        {
            var publisher = await _mediator.Send(request);
            if (!publisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(publisher.Valid));
            }
            if (publisher.Data != null)
            { 
                var uri = _urlHelper.GetUri(publisher.Data.Id.ToString());
                return Created(uri, new Response<Publisher>(publisher.Data));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getPublisherAsync(int id)
        {
            var query = new GetPublisherByIdQuery(id);
            var publisher = await _mediator.Send(query);
            if (!publisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(publisher.Valid));
            }
            if (publisher.Data != null)
            { 
                return Ok(new Response<Publisher>(publisher.Data));
            }
            return BadRequest("Invalid Id");
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editPublisherAsync(int id, [FromBody] EditPublisherCommand request)
        {
            var command = new EditPublisherWithIdCommand(request,id);
            var publisher = await _mediator.Send(command);
            if (!publisher.Valid.IsValid)
            {
                
                return BadRequest(erroResponse(publisher.Valid));
            }
            if (publisher.Data != null)
            { 
                var uri = _urlHelper.GetUri(publisher.Data.Id.ToString());
                return Ok(new Response<Publisher>(publisher.Data));
            }
            return BadRequest("Invalid Id");
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deletePublisherAsync(int id)
        {
            var query = new DeletePublisherByIdCommand(id);
            var publisher = await _mediator.Send(query);
            if (!publisher.Valid.IsValid)
            {
                return BadRequest(erroResponse(publisher.Valid));
            }
            if (publisher.Data)
            { 
                return Ok();
            }
            return BadRequest("Invalid Id");
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
