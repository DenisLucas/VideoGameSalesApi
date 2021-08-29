using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Api.Controllers.Games;
using VideoGameSales.Util.Helpers;
using Xunit;

namespace VideoGameSales.Tests
{
    public class GameControllerTest
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;
        
        public GameControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _urlHelper = A.Fake<UrlHelpers>();
            _mapper = A.Fake<IMapper>();
        }
        
        [Fact]
        private Task createGameSaleShouldReturn201Created()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.createGameAsync(CreateGameCommand request);
            var isCreated = action as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private Task getGameShouldReturn200Ok()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.getGameAsync(GetGameQuery request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        [Fact]
        private Task editGameSaleShouldReturn200Ok()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.editGameAsync(EditGameCommand request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private Task deleteGameSaleShouldReturn200Ok()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.deleteGameAsync(int request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
    }
}
