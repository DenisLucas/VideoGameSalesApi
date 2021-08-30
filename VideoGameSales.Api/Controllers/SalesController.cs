using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Core.Sales.Query;
using VideoGameSales.Domain.ViewModels.Sales;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost]
        public async Task<IActionResult> createSalesAsync([FromBody] CreateSalesCommand request)
        {
            var sale = await _mediator.Send(request);
            if (sale != null)
            { 
                var uri = _urlHelper.GetUri(sale.Id.ToString());
                var response = _mapper.Map<SaleViewModel>(sale);
                return Created(uri, new Response<SaleViewModel>(response));
            }
            return BadRequest();
        }
        [HttpGet("/{gameId}/{platformId}")]
        public async Task<IActionResult> getSalesAsync(int gameId,int platformId)
        {
            var query = new GetSalesByIdQuery(gameId,platformId);
            var sale = await _mediator.Send(query);
            if (sale != null)
            { 
                var uri = _urlHelper.GetUri(sale.Id.ToString());
                var response = _mapper.Map<SaleViewModel>(sale);
                return Ok(new Response<SaleViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> editSalesAsync(int id, [FromBody] EditSalesCommand request)
        {
            var command = new EditSalesWithIdCommand(id,request);
            var sale = await _mediator.Send(command);
            if (sale != null)
            { 
                var uri = _urlHelper.GetUri(sale.Id.ToString());
                var response = _mapper.Map<SaleViewModel>(sale);
                return Ok(new Response<SaleViewModel>(response));
            }
            return BadRequest();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> deleteSalesAsync(int id)
        {
            var query = new DeleteSalesByIdCommand(id);
            var game = await _mediator.Send(query);
            if (game != null)
            { 
                var response = _mapper.Map<SaleViewModel>(game);
                return Ok(new Response<SaleViewModel>(response));
            }
            return BadRequest();
        }
    }
}