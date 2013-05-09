using System;
using System.Collections.Generic;
using Search.Data.Models;
using System.ComponentModel.DataAnnotations;


namespace Search.Components.Html.ViewModels
{
    public class ParcelViewModel
    {
        [Obsolete]
        public string PREV_ID { get; set;}
        [Obsolete]
        public string NEXT_ID { get; set; }

        //[DisplayFormat(DataFormatString="0:N0"),Display(Name="Gross Area")] 
        //public int TOTAL_GROSS_AREA { get; set; }

        //[DisplayFormat(DataFormatString = "0:N0"), Display(Name = "Living Area")] 
        //public int TOTAL_LIVING_AREA { get; set; }

        public string STRAP { get; set; }
        public string PROPERTY_ID { get; set; }
        public string SITUS { get; set; }
        public string MAILING_ADDRESS { get; set; }
        public string PROPERTY_USE { get; set; }
        public string SUBDIVISION { get; set; }
        public string ASSESSMENT_DESCRIPTION { get; set; }
        public string MUNICIPALITY_NAME { get; set; }
        public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}"), Display(Name = "Land Area")] 
        public int LAND_AREA { get; set; }
        public string INCORPORATION { get; set; }
        public string SEC_TWP_RGE { get; set; }
        public string CENSUS { get; set; }
        public string DELINEATED_DISTRICT { get; set; }

        public IList<Owner> Owners { get; set; }
        public IList<Characteristic> Characteristics { get; set; }
        public IList<Building> Buildings { get; set; }
        public IList<ExtraFeature> ExtraFeatures { get; set; }
        public IList<Transfer> Transfers { get; set; }

        public IList<NonAdValorem> NonAdValorems { get; set; }
        public IList<AdValorem> AdValorems { get; set; }
        public IList<ParcelValuation> ParcelValuations { get; set; }

        public IList<Exemption> Exemptions { get; set; }


        private string FormattedForWeb(string strap){

            string result = "";

            if (!String.IsNullOrEmpty(strap)){
                result = String.Format("{0}-{1}-{2}", STRAP.Substring(0, 4), STRAP.Substring(4, 2), STRAP.Substring(6, 4));  
            }
        else {
        result = "N/A";
    }


             return result;
        }
        
    }

}