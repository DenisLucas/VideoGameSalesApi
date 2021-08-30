using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using VideoGameSales.Core.Games.Query;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.Games;
using Xunit;
namespace VideoGameSales.Tests.Handlers
{
    public class GameHandlersTest
    {
        private readonly IMediator _mediator;
        public GameHandlersTest()
        {

            
            _mediator = A.Fake<IMediator>();
        }
    
        [Fact]
        private async Task createGameShouldReturnGameViewModel()
        {
                var _game = new CreateGameCommand
                {
                    Name = "Denis",
                    Ranks = 1000,
                    Genre = "Horror",
                    Release_year = 2000
                };
            var Data = A.CollectionOfDummy<Game>(10);
            
            var handler = A.Fake<CreateGameCommandHandler>();    
            A.CallTo(() => handler(_game)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_game);

            Assert.Equal(11,Data.Count);

        }

        [Fact]
        private async Task editGameShouldReturnGameViewModel()
        {
            var _game = new EditGameIdCommand
                {
                    Id = 0,
                    Name = "Denis",
                    Ranks = 1000,
                    Genre = "Horror",
                    Release_year = 2000
                };
            var Data = A.CollectionOfDummy<Game>(10);
            
            var handler = A.Fake<EditGameCommandHandler>();    
            A.CallTo(() => handler(_game)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_game);
            Assert.Equal(new Game(), action);

        }
        
        [Fact]
        private async Task deleteGameShouldReturnGameViewModel()
        {
            var _game = new DeleteGameCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<Game>(10);
            
            var handler = A.Fake<DeleteGameCommandHandler>();    
            A.CallTo(() => handler(_game)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_game);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new Game(),handler);

        }
        
        [Fact]
        private async Task getGameShouldReturnGameViewModel()
        {

            
            var Data = A.CollectionOfDummy<Game>(10);
            var _game = new GetGameByIdQuery(2);
            var handler = A.Fake<GetGameCommandHandler>();    
            A.CallTo(() => handler(_game)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_game);
            Assert.Equal(new Game(),handler);

        }
    }
}
