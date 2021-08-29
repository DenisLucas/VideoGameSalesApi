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
    public class GamesToPlatformControllerTest
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;
        
        public GamesToPlatformControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _urlHelper = A.Fake<UrlHelpers>();
            _mapper = A.Fake<IMapper>();
        }
        
        [Fact]
        private Task createGameToPlatformShouldReturn201Created()
        {
            var gameController = new GameToPlatformController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.createGameToPlatformAsync(CreateGameToPlatformCommand request);
            var isCreated = action as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private Task getGameToPlatformShouldReturn200Ok()
        {
            var gameController = new GameToPlatformController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.getGameToPlatformAsync(GetGameToPlatformQuery request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        [Fact]
        private Task editGameToPlatformShouldReturn200Ok()
        {
            var gameController = new GameToPlatformController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.editGameToPlatformAsync(EditGameToPlatformCommand request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private Task deleteGameToPlatformShouldReturn200Ok()
        {
            var gameController = new GameToPlatformController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.deleteGameToPlatformAsync(0);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
    }
}
