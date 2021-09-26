using System;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Api.Controllers;
using VideoGameSales.Core.GameToPlatform.Command;
using VideoGameSales.Core.GameToPublisher.Command;
using VideoGameSales.Util.Helpers;
using Xunit;

namespace VideoGameSales.Tests.Controllers
{
    public class GamesToPublisherControllerTest
    {
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;
        private readonly IMapper _mapper;
        
        public GamesToPublisherControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _urlHelper = A.Fake<UrlHelpers>();
            _mapper = A.Fake<IMapper>();
        }
        
        [Fact]
        private void createGameToPublisherShouldReturn201Created()
        {
            var gameController = new GamesToPublisherController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<CreateGameToPublisherCommand>();
            var action = gameController.createGameToPublisherAsync(request);
            var isCreated = action.Result as CreatedResult;

            Assert.Equal(201, isCreated.StatusCode);
        }

        [Fact]
        private void getGameToPublisherShouldReturn200Ok()
        {
            var gameController = new GamesToPublisherController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.getGameToPublisherAsync(3);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        [Fact]
        private void editGameToPublisherShouldReturn200Ok()
        {
            var gameController = new GamesToPublisherController(_mediator,_mapper,_urlHelper);
            var request = A.Dummy<EditGameToPublisherCommand>();
            var action = gameController.editGameToPublisherAsync(4,request);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
        
        [Fact]
        private void deleteGameToPublisherShouldReturn200Ok()
        {
            var gameController = new GamesToPublisherController(_mediator,_mapper,_urlHelper);
            
            var action = gameController.deleteGameToPublisherAsync(0);
            var isOk = action.Result as OkObjectResult;
            Assert.Equal(200, isOk.StatusCode);
        }
    }
}
