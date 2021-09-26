using System;
using AutoMapper;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;

namespace VideoGameSales.Domain.Mappings
{
    public class GameToPublisherToGameToPublisherViewModel : Profile
    {
        public GameToPublisherToGameToPublisherViewModel()
        {
            CreateMap<PublishersToGames,GameToPublisherViewModel>(); 
            CreateMap<GameToPublisherViewModel, PublishersToGames>();
        }
    }
}
