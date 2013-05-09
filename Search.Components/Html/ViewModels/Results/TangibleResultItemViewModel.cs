using Search.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Search.Components.Html.ViewModels
{
    public class TangibleResultItemViewModel : IResultItemViewModel
    {
        [Display(Name="Account Number")] 
        public string AccountNumber { get; set; }
        [Display(Name="AddressKeywords")]
        public string PropertyAddress { get; set; }

        [Display(Name="Owner")] 
        public string OwnerName { get; set; }

    }

}