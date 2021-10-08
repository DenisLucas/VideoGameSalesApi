using System;
using AutoMapper;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.ViewModels.Publishers;

namespace VideoGameSales.Domain.Mappings
{
    public class PublishersToPublishersViewModel : Profile
    {
        public PublishersToPublishersViewModel()
        {
            CreateMap<Publisher, PublisherViewModel>();

            CreateMap<PublisherViewModel, Publisher>();
        }
    }
}
