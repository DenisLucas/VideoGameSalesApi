using System;
using AutoMapper;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Domain.Mappings
{
    public class GameToGameViewModel : Profile
    {
        public GameToGameViewModel()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<GameViewModel,Game>();
        }
    }
}
