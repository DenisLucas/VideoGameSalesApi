using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Core.Publishers.Query;
using VideoGameSales.Domain.ViewModels.Publishers;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{
    [ApiController]
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
            if (publisher != null)
            { 
                var uri = _urlHelper.GetUri(publisher.Id.ToString());
                var response = _mapper.Map<PublisherViewModel>(publisher);
                return Created(uri, new Response<PublisherViewModel>(response));
            }
            return BadRequest();
        }
        [HttpGet(_base + "/{id}")]
        public async Task<IActionResult> getPublisherAsync(int id)
        {
            var query = new GetPublisherByIdQuery(id);
            var publisher = await _mediator.Send(query);
            if (publisher != null)
            { 
                var uri = _urlHelper.GetUri(publisher.Id.ToString());
                var response = _mapper.Map<PublisherViewModel>(publisher);
                return Ok(new Response<PublisherViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editPublisherAsync(int id, [FromBody] EditPublisherCommand request)
        {
            var command = new EditPublisherWithIdCommand(request,id);
            var publisher = await _mediator.Send(command);
            if (publisher != null)
            { 
                var uri = _urlHelper.GetUri(publisher.Id.ToString());
                var response = _mapper.Map<PublisherViewModel>(publisher);
                return Ok(new Response<PublisherViewModel>(response));
            }
            return BadRequest();
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deletePublisherAsync(int id)
        {
            var query = new DeletePublisherByIdCommand(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var response = _mapper.Map<PublisherViewModel>(game);
                return Ok(new Response<PublisherViewModel>(response));
            }
            return BadRequest();
        }
    }
}
