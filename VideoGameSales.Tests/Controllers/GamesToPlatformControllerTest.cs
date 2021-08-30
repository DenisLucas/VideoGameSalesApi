using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Api.Controllers;
using VideoGameSales.Core.GameToPlatform.Command;
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
        private void createGameToPlatformShouldReturn201Created()
        {
            var gameController = new GamesToPlatformController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<CreateGameToPlatformCommand>();
            var action = gameController.createGameToPlatformAsync(request);
            var isCreated = action.Result as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private void getGameToPlatformShouldReturn200Ok()
        {
            var gameController = new GamesToPlatformController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.getGameToPlatformAsync(2);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        [Fact]
        private void editGameToPlatformShouldReturn200Ok()
        {
            var gameController = new GamesToPlatformController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<EditGameToPlatformCommand>();
            var action = gameController.editGameToPlatformAsync(4,request);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private void deleteGameToPlatformShouldReturn200Ok()
        {
            var gameController = new GamesToPlatformController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.deleteGameToPlatformAsync(0);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
    }
}
