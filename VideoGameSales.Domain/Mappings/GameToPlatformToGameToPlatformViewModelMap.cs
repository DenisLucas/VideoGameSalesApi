using System;
using AutoMapper;
using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.ViewModels.Connectors;

namespace VideoGameSales.Domain.Mappings
{
    public class GameToPlatformToGameToPlatformViewModelMap : Profile
    {
        public GameToPlatformToGameToPlatformViewModelMap()
        {
            CreateMap<GamesToPlataform, GameToPlatformViewModel>();
            CreateMap<GameToPlatformViewModel,GamesToPlataform>();
        }
    }
}
