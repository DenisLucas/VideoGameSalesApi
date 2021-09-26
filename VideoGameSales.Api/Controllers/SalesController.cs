using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Core.Sales.Command;
using VideoGameSales.Core.Sales.Query;
using VideoGameSales.Domain.Errors;
using VideoGameSales.Domain.ViewModels.Sales;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{

    [ApiController]
    public class SalesController : ControllerBase
    {
        private const string _base = "api/sale"; 
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, IMapper mapper, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _mapper = mapper;
            _urlHelper = urlHelpers;
        }
        [HttpPost(_base)]
        public async Task<IActionResult> createSalesAsync([FromBody] CreateSalesCommand request)
        {
            var sale = await _mediator.Send(request);
            if (!sale.Valid.IsValid)
            {
                return BadRequest(erroResponse(sale.Valid));
            }            
            if (sale.Data != null)
            { 
                var uri = _urlHelper.GetUri(sale.Data.Id.ToString());
                var response = _mapper.Map<SaleViewModel>(sale);
                return Created(uri, new Response<SaleViewModel>(response));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }
        [HttpGet(_base + "/{gameId}/{platformId}")]
        public async Task<IActionResult> getSalesAsync(int gameId,int platformId)
        {
            var query = new GetSalesByIdQuery(gameId,platformId);
            var sale = await _mediator.Send(query);
            if (!sale.Valid.IsValid)
            {
                return BadRequest(erroResponse(sale.Valid));
            }            
            if (sale.Data != null)
            { 
                var uri = _urlHelper.GetUri(sale.Data.Id.ToString());
                var response = _mapper.Map<SaleViewModel>(sale);
                return Ok(new Response<SaleViewModel>(response));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }

        [HttpPut(_base + "/{id}")]
        public async Task<IActionResult> editSalesAsync(int id, [FromBody] EditSalesCommand request)
        {
            var command = new EditSalesWithIdCommand(id,request);
            var sale = await _mediator.Send(command);
            if (!sale.Valid.IsValid)
            {
                return BadRequest(erroResponse(sale.Valid));
            }            
            if (sale.Data != null)
            { 
                var uri = _urlHelper.GetUri(sale.Data.Id.ToString());
                var response = _mapper.Map<SaleViewModel>(sale);
                return Ok(new Response<SaleViewModel>(response));
            }
            return BadRequest(new ErrorModel{FieldName = "Id", ErrorMessage = "Invalid Id"});
        }

        [HttpDelete(_base + "/{id}")]
        public async Task<IActionResult> deleteSalesAsync(int id)
        {
            var query = new DeleteSalesByIdCommand(id);
            var sale = await _mediator.Send(query);
            if (!sale.Valid.IsValid)
            {
                return BadRequest(erroResponse(sale.Valid));
            }            
            if (sale.Data)
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
