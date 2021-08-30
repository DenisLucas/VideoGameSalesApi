using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Api.Controllers;
using VideoGameSales.Core.Platforms.Command;
using VideoGameSales.Util.Helpers;
using Xunit;

namespace VideoGameSales.Tests
{
    public class PlatformControllerTest
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;
        
        public PlatformControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _urlHelper = A.Fake<UrlHelpers>();
            _mapper = A.Fake<IMapper>();
        }
        
        [Fact]
        private Task createPlatformShouldReturn201Created()
        {
            var gameController = new PlatformController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<CreatePlatformCommand>();
            var action = gameController.createPlatformAsync(request);
            var isCreated = action.Result as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private Task getPlatformShouldReturn200Ok()
        {
            var platformController = new PlatformController(_mediator,_mapper,_urlHelper);
            
            var action = platformController.getPlatformAsync(4);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        [Fact]
        private Task editPlatformShouldReturn200Ok()
        {
            var platformController = new PlatformController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<EditPlatformCommand>();
            var action = platformController.editPlatformAsync(3,request);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private Task deletePlatformShouldReturn200Ok()
        {
            var platformController = new PlatformController(_mediator,_mapper,_urlHelper);
            
            var action = platformController.deletePlatformAsync(5);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }

    }
}