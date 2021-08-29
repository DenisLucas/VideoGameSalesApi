using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using Xunit;

namespace VideoGameSales.Tests.Handlers
{
    public class GameToPlatformHandlersTest
    {
        private readonly IMediator _mediator;
        public GameToPlatformHandlersTest()
        {
            _mediator = A.Fake<IMediator>();
        }
    
        [Fact]
        private async Task createGamesToPlatformShouldReturnGameViewModel()
        {
            var _platform = new CreateGamesToPlatformCommand
            {
                Platform_id = 0,
                Game_id = 1
            };
            var Data = A.CollectionOfDummy<GamesToPlatform>(10);
            
            var handler = A.Fake<CreateGamesToPlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(11,Data.Count);

        }

        [Fact]
        private async Task editGamesToPlatformShouldReturnGameViewModel()
        {
            var _platform = new EditGamesToPlatformIdCommand
            {
                Id = 0,
                Platform_id = 0,
                Game_id = 1

            };
            var Data = A.CollectionOfDummy<GamesToPlatform>(10);
            
            var handler = A.Fake<EditGamesToPlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(new GamesToPlatformViewModel(), action);

        }
        
        [Fact]
        private async Task deleteGamesToPlatformShouldReturnGameViewModel()
        {
            var _platform = new DeleteGamesToPlatformCommand
            {
                Id = 0,
            };
            var Data = A.CollectionOfDummy<GamesToPlatform>(10);
            
            var handler = A.Fake<DeleteGamesToPlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new GamesToPlatformViewModel(),handler);

        }
        
        [Fact]
        private async Task getGamesToPlatformShouldReturnGameViewModel()
        {
            var _platform = new GetGamesToPlatformCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<GamesToPlatform>(10);
            
            var handler = A.Fake<GetGamesToPlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new GamesToPlatformViewModel(),handler);
        }
    }
}
