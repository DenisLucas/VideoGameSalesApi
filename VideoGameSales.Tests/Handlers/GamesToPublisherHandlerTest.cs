using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using VideoGameSales.Domain.Entities.Conectors;
using Xunit;

namespace VideoGameSales.Tests.Handlers
{
    public class GamesToPublisherHandlerTest
    {
            private readonly IMediator _mediator;
        public GamesToPublisherHandlerTest()
        {
            _mediator = A.Fake<IMediator>();
        }
    
        [Fact]
        private async Task createGamesToPublisherShouldReturnGameViewModel()
        {
            var _platform = new CreateGamesToPublisherCommand
            {
                Publisher_id = 0,
                Game_id = 1
            };
            var Data = A.CollectionOfDummy<GamesToPublisher>(10);
            
            var handler = A.Fake<CreateGamesToPublisherCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(11,Data.Count);

        }

        [Fact]
        private async Task editGamesToPublisherShouldReturnGameViewModel()
        {
            var _platform = new EditGamesToPublisherIdCommand
            {
                Id = 0,
                Publisher_id = 0,
                Game_id = 1

            };
            var Data = A.CollectionOfDummy<GamesToPublisher>(10);
            
            var handler = A.Fake<EditGamesToPublisherCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(new GamesToPublisherViewModel(), action);

        }
        
        [Fact]
        private async Task deleteGamesToPublisherShouldReturnGameViewModel()
        {
            var _platform = new DeleteGamesToPublisherCommand
            {
                Id = 0,
            };
            var Data = A.CollectionOfDummy<GamesToPublisher>(10);
            
            var handler = A.Fake<DeleteGamesToPublisherCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new GamesToPublisherViewModel(),handler);

        }
        
        [Fact]
        private async Task getGamesToPublisherShouldReturnGameViewModel()
        {
            var _platform = new GetGamesToPublisherCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<GamesToPublisher>(10);
            
            var handler = A.Fake<GetGamesToPublisherCommandHandler>();    
            A.CallTo(() => handler(_platform)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_platform);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new GamesToPublisherViewModel(),handler);

    }
}
