using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Search.Data.Models;
using System.Runtime.Serialization;

namespace Search.Components.Html.ViewModels
{
    public class BuildingViewModel
    {
        public string Strap { get; set; }
        public int NUM { get; set; }
        public string SITUS { get; set; }
        public string TYPE { get; set; }
        public string STYLE { get; set; }
        public string CLASS { get; set; }
        public int? YEAR_BUILT { get; set; }
        public int? GROSS_AREA { get; set; }
        public int? LIVING_AREA { get; set; }

        public int? BEDS { get; set; }
        public int? BATHS { get; set; }
        public int? HALF_BATHS { get; set; }
        public int? ROOMS { get; set; }
        public int? LIVING_UNITS { get; set; }
        public int? STORY_NUM { get; set; }

        public IList<ExtraFeature> ExtraFeatures { get; set; }
        public IList<StructuralElement> StructuralElements { get; set; }
        public IList<SubArea> SubAreas { get; set; }



    }

}