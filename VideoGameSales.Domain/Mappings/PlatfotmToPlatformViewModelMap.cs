
using AutoMapper;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.ViewModels.Platforms;

namespace VideoGameSales.Domain.Mappings
{

    public class PlatfotmToPlatformViewModelMap : Profile
    {
        public PlatfotmToPlatformViewModelMap()
        {
            CreateMap<Platform,PlatformViewModel>();

            CreateMap<PlatformViewModel,Platform>();
        }
    }
}