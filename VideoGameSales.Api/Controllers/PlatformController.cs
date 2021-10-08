using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.FIlters.validators.Platform;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Core.Platforms.Query;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Domain.Errors;
using VideoGameSales.Domain.ViewModels.Platforms;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{
    [ApiController]
    [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class PlatformController : ControllerBase
    {
        public const string _base = "api/platform";
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public PlatformController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost(_base)]
        public async Task<IActionResult> createPlatformAsync([FromBody] CreatePlatformCommand request)
        {
            var platform = await _mediator.Send(request);   
            if (!platform.Valid.IsValid)
            {
               return BadRequest(erroResponse(platform.Valid));
            }         
            if (platform != null)
            { 
                var uri = _urlHelper.GetUri(platform.Id.ToString());
                return Created(uri, new Response<PlatformViewModel>(platform.Data));
            }
            return BadRequest();
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getPlatformAsync(int id)
        {
            var query = new GetPlatformByIdQuery(id);
            var platform = await _mediator.Send(query);
            if (!platform.Valid.IsValid)
            {
               return BadRequest(erroResponse(platform.Valid));;
            }         
            
            if (platform.Data != null)
            { 
                return Ok(new Response<PlatformViewModel>(platform.Data));
            }
            return BadRequest("Invalid Id");
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editPlatformAsync(int id, [FromBody] EditPlatformCommand request)
        {
            var command = new EditPlatformWithIdCommand(id,request);
            var platform = await _mediator.Send(command);
            if (!platform.Valid.IsValid)
            {
               return BadRequest(erroResponse(platform.Valid));;
            }
            if (platform.Data != null)
            { 
                var uri = _urlHelper.GetUri(platform.Id.ToString());
                return Ok(new Response<PlatformViewModel>(platform.Data));
            }
            return BadRequest("Invalid Id");
        }


        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deletePlatformAsync(int id)
        {
            var command = new DeletePlatformByIdCommand(id);
            var platform = await _mediator.Send(command);
            
            if (!platform.Valid.IsValid)
            {
               return BadRequest(erroResponse(platform.Valid));;
            }             
            if (platform.Data)
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
