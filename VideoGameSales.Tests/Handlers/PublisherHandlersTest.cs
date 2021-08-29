using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using VideoGameSales.Domain.Entities.Publishers;
using Xunit;

namespace VideoGameSales.Tests.Handlers
{
    public class PublisherHandlersTest
    {
        private readonly IMediator _mediator;
        public PublisherHandlersTest()
        {
            _mediator = A.Fake<IMediator>();
        }
    
        [Fact]
        private async Task createPublisherShouldReturnGameViewModel()
        {
                var _publisher = new CreatePublisherCommand
                {
                    Name = "Denis"
                };
            var Data = A.CollectionOfDummy<Publisher>(10);
            
            var handler = A.Fake<CreatePublisherCommandHandler>();    
            A.CallTo(() => handler(_publisher)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_publisher);

            Assert.Equal(11,Data.Count);

        }

        [Fact]
        private async Task editPublisherShouldReturnGameViewModel()
        {
            var _publisher = new EditPublisherIdCommand
                {
                    Id = 0,
                    Name = "Denis",
                };
            var Data = A.CollectionOfDummy<Publisher>(10);
            
            var handler = A.Fake<EditPublisherCommandHandler>();    
            A.CallTo(() => handler(_publisher)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_publisher);
            Assert.Equal(new PublisherViewModel(), action);

        }
        
        [Fact]
        private async Task deletePublisherShouldReturnGameViewModel()
        {
            var _publisher = new DeletePublisherCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<Publisher>(10);
            
            var handler = A.Fake<DeletePublisherCommandHandler>();    
            A.CallTo(() => handler(_publisher)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_publisher);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new PublisherViewModel(),handler);

        }
        
        [Fact]
        private async Task getPublisherShouldReturnGameViewModel()
        {
            var _publisher = new GetPublisherCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<Publisher>(10);
            
            var handler = A.Fake<GetPublisherCommandHandler>();    
            A.CallTo(() => handler(_publisher)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_publisher);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new PublisherViewModel(),handler);

        }
    }
}
