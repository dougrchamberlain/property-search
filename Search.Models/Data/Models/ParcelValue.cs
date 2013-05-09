using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Search.Data.Models
{

    [Table("PARCEL_VALUES")]
    public class ParcelValuation
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public string STRAP { get; set; }

        [Display(Name = "Year")]
        public int YEAR { get; set; }

        [Display(Name = "Land"),DisplayFormat(DataFormatString="{0:C0}")  ]
        public int LAND { get; set; }

        [Display(Name = "Building"), DisplayFormat(DataFormatString = "{0:C0}")]
        public int BUILDING { get; set; }

        [Display(Name = "Extra Feature"), DisplayFormat(DataFormatString = "{0:C0}")]
        public int EXTRA_FEATURE { get; set; }

        [Display(Name = "Just"), DisplayFormat(DataFormatString = "{0:C0}")]
        public int JUST { get; set; }

        [Display(Name = "Assessed"), DisplayFormat(DataFormatString = "{0:C0}")]
        public int ASSESSED { get; set; }

        [Display(Name = "Exemptions"), DisplayFormat(DataFormatString = "{0:C0}")]
        public int EXEMPTIONS { get; set; }

        [Display(Name = "Taxable"), DisplayFormat(DataFormatString = "{0:C0}")]
        public int TAXABLE { get; set; }

    }
}