using System;
using AutoMapper;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Domain.Mappings
{
    public class GameToGameViewModelMap : Profile
    {
        public GameToGameViewModelMap()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<GameViewModel,Game>();
        }
    }
}
