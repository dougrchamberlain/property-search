using System;

namespace Search.Components.Html.ViewModels
{
    public class SearchSalesViewModel
    {
        public DateTime? SalesFrom { get; set; }
        public DateTime? SalesTo { get; set; }
        public int? SaleAmountFrom { get; set; }
        public int? SaleAmountTo { get; set; }

        public string InstrumentNumber { get; set; }

        [Obsolete]
        public string InstrumentType { get; set; }

        public string GrantorSeller { get; set; }
    }
}