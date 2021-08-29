using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        private Task createPublishersShouldReturn201Created()
        {
            var publishersController = new PublishersController(_mediator,_mapper,_urlHelper);
            
            var action = publishersController.createPublishersAsync(CreatePublishersCommand request);
            var isCreated = action as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private Task getPublishersShouldReturn200Ok()
        {
            var publishersController = new PublishersController(_mediator,_mapper,_urlHelper);
            
            var action = publishersController.getPublishersAsync(GetPublishersQuery request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private Task deletePublishersShouldReturn200Ok()
        {
            var publishersController = new PublishersController(_mediator,_mapper,_urlHelper);
            
            var action = publishersController.deletePublishersAsync(0);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        private Task editPublishersShouldReturn200Ok()
        {
            var publishersController = new PublishersController(_mediator,_mapper,_urlHelper);
            
            var action = publishersController.editPublishersAsync(EditPublishersCommand request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }

    }
}
