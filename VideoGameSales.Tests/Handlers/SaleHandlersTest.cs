using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using VideoGameSales.Domain.Entities.Sales;
using Xunit;

namespace VideoGameSales.Tests.Handlers
{
    public class SaleHandlersTest
    {
        private readonly IMediator _mediator;
        public SaleHandlersTest()
        {
            _mediator = A.Fake<IMediator>();
        }
    
        [Fact]
        private async Task createSaleShouldReturnGameViewModel()
        {
            var _sale = new CreateSaleCommand
            {
                GamesToPlatforms_id = 0,
                Sales_Na = 1,
                Sales_Eu = 3,
                Sales_Jp = 5,
                Sales_Other = 0.5,
                Sales_Global = 50
            };
            var Data = A.CollectionOfDummy<Sale>(10);
            
            var handler = A.Fake<CreateSaleCommandHandler>();    
            A.CallTo(() => handler(_sale)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_sale);
            Assert.Equal(11,Data.Count);

        }

        [Fact]
        private async Task editSaleShouldReturnGameViewModel()
        {
            var _sale = new EditSaleIdCommand
            {
                Id = 0,
                GamesToPlatforms_id = 0,
                Sales_Na = 1,
                Sales_Eu = 3,
                Sales_Jp = 5,
                Sales_Other = 0.5,
                Sales_Global = 50
            };
            var Data = A.CollectionOfDummy<Sale>(10);
            
            var handler = A.Fake<EditSaleCommandHandler>();    
            A.CallTo(() => handler(_sale)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_sale);
            Assert.Equal(new SaleViewModel(), action);

        }
        
        [Fact]
        private async Task deletePlatformShouldReturnGameViewModel()
        {
            var _sale = new DeleteSaleCommand
            {
                Id = 0,
                
            };
            var Data = A.CollectionOfDummy<Sale>(10);
            
            var handler = A.Fake<DeleteSaleCommandHandler>();    
            A.CallTo(() => handler(_sale)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_sale);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new SaleViewModel(),handler);

        }
        
        [Fact]
        private async Task getPublisherShouldReturnGameViewModel()
        {
            var _sale = new GetSaleCommand
                {
                    Id = 0,
                };
            var Data = A.CollectionOfDummy<Sale>(10);
            
            var handler = A.Fake<GetSaleCommandHandler>();    
            A.CallTo(() => handler(_sale)).Returns(Task.FromResult(Data));

            var action = await _mediator.Send(_sale);
            Assert.Equal(9, Data.Count);
            Assert.Equal(new SaleViewModel(),handler);
    }
}
