using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using VideoGameSales.Domain.Entities.Platforms;
using Xunit;

namespace VideoGameSales.Tests.Handlers
{
    public class PlatformHandlersTest
    {
        private readonly IMediator _mediator;
        public PlatformHandlersTest()
        {
            _mediator = A.Fake<IMediator>();
        }
    
        [Fact]
        private async Task createPlatformShouldReturnGameViewModel()
        {
            var _platform = new CreatePlatformCommand
            {
                Name = "Denis"
            };
            var Data = A.CollectionOfDummy<Platform>(10);
            
            var handler = A.Fake<CreatePlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(11,Data.Count);

        }

        [Fact]
        private async Task editPlatformShouldReturnGameViewModel()
        {
            var _platform = new EditPlatformIdCommand
            {
                Id = 0,
                Name = "Denis",
            };
            var Data = A.CollectionOfDummy<Platform>(10);
            
            var handler = A.Fake<EditPlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(new PlatformViewModel(), action);

        }
        
        [Fact]
        private async Task deletePlatformShouldReturnGameViewModel()
        {
            var _platform = new DeletePlatformCommand
            {
                Id = 0,
            };
            var Data = A.CollectionOfDummy<Platform>(10);
            
            var handler = A.Fake<DeletePlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new PlatformViewModel(),handler);

        }
        
        [Fact]
        private async Task getPlatformShouldReturnGameViewModel()
        {
            var _platform = new GetPlatformCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<Platform>(10);
            
            var handler = A.Fake<GetPlatformCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new PlatformViewModel(),handler);
        }
    }
}
