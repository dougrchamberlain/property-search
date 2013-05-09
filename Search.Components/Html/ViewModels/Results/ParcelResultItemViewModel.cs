using Search.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Search.Components.Html.ViewModels
{
    public class ParcelResultItemViewModel : IResultItemViewModel
    {
        public string STRAP { get; set; }
        public IList<Owner> OWNERS { get; set; }
        public string SITUS { get; set; }
        public string SUBDIVISION_PROPERTY_USE { get; set; }
        [Display(Name="Pool") ]
        public bool Pool { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}