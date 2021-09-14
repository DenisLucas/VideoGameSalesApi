using System;
using AutoMapper;
using VideoGameSales.Domain.Entities.Sales;
using VideoGameSales.Domain.ViewModels.Sales;

namespace VideoGameSales.Domain.Mappings
{
    public class SalesToSalesViewModel : Profile
    {
        public SalesToSalesViewModel()
        {
            CreateMap<Sale, SaleViewModel>();

            CreateMap<SaleViewModel,Sale>();
        }
    }
}
