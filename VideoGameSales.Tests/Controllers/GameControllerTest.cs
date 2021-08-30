using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Api.Controllers.Games;
using VideoGameSales.Core.Games;
using VideoGameSales.Core.Games.Command;
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
        private async Task createGameShouldReturn201Created()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            var request =  A.Dummy<CreateGameCommand>();
            var action = await gameController.createGameAsync(request);
            var isCreated = action as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private async Task getGameShouldReturn200Ok()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            var action = await gameController.getGameAsync(0);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        [Fact]
        private async Task editGameShouldReturn200Ok()
        {
            var gameController = new GameController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<EditGameCommand>();
            var action = await gameController.editGameAsync(3,request);
            var isOk = action as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
    }
}
