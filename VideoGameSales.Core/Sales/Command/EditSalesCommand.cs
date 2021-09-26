using System;

namespace VideoGameSales.Core.Sales.Command
{
    public class EditSalesCommand
    {
        public int GamesToPlatforms_id { get; set; }
        public float Sales_Na { get; set; }
        public float Sales_Eu { get; set; }
        public float Sales_Jp { get; set; }
        public float Sales_Other { get; set; }
        public float Sales_Global { get; set; }
    }
}
