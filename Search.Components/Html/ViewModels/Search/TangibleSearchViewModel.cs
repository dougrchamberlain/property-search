using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Search.Components.Html.ViewModels
{
    public class TangibleSearchViewModel 
    {
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string BusinessName { get; set; }
        public string DoingBusinessAs { get; set; }

        public List<NaicsCodeViewModel> NaicsCodeList { get; set; }
        public int[] SelectedNaicsCode {get;set;}

        public string LocalBusinessTax { get; set; }

        public List<TangibleResultItemViewModel> SearchResults { get; set; } 

    }
}
