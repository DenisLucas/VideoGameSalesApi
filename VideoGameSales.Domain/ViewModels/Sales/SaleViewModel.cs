using System;

namespace VideoGameSales.Domain.ViewModels.Sales
{
    public class SaleViewModel
    {
        public float Sales_Na { get; set; }
        public float Sales_Eu { get; set; }
        public float Sales_Jp { get; set; }
        public float Sales_Other { get; set; }
        public float Sales_Global { get; set; }
    }
}
