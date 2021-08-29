using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Util.Helpers;
using Xunit;

namespace VideoGameSales.Tests
{
    public class SalesControllerTest
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;
        
        public SalesControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _urlHelper = A.Fake<UrlHelpers>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        private Task createSalesShouldReturn201Created()
        {
            var salesController = new SalesController(_mediator,_mapper,_urlHelper);
            
            var action = salesController.createSalesAsync(CreateSalesCommand request);
            var isCreated = action as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private Task getSalesShouldReturn200Ok()
        {
            var salesController = new SalesController(_mediator,_mapper,_urlHelper);
            
            var action = salesController.getSalesAsync(GetSalesQuery request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private Task deleteSalesShouldReturn200Ok()
        {
            var salesController = new SalesController(_mediator,_mapper,_urlHelper);
            
            var action = salesController.deleteSalesAsync(0);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }

        [Fact]
        private Task editSalesShouldReturn200()
        {
            var SalesController = new SalesController(_mediator,_mapper,_urlHelper);
            
            var action = SalesController.editSalesAsync(EditSalesCommand request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
    }
}
