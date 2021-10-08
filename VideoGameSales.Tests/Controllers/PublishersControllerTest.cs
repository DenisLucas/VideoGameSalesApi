using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Api.Controllers;
using VideoGameSales.Core.Publishers.Command;
using VideoGameSales.Util.Helpers;
using Xunit;

namespace VideoGameSales.Tests.Controllers
{
    public class PublishersControllerTest
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;
        
        public PublishersControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _urlHelper = A.Fake<UrlHelpers>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        private void createPublisherShouldReturn201Created()
        {
            var publishersController = new PublisherController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<CreatePublisherCommand>();
            var action = publishersController.createPublisherAsync(request);
            var isCreated = action.Result as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private void getPublisherShouldReturn200Ok()
        {
            var publishersController = new PublisherController(_mediator,_mapper,_urlHelper);
            
            var action = publishersController.getPublisherAsync(6);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private void deletePublisherShouldReturn200Ok()
        {
            var publishersController = new PublisherController(_mediator,_mapper,_urlHelper);
            
            var action = publishersController.deletePublisherAsync(0);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        private void editPublisherShouldReturn200Ok()
        {
            var publishersController = new PublisherController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<EditPublisherCommand>();
            var action = publishersController.editPublisherAsync(3,request);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }

    }
}
