using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("BUILDINGS")]
    public class Building
    {
        [ScaffoldColumn(false)]
        [Key, Column(Order = 0), MaxLength(16)]
        public virtual string STRAP { get; set; }
        [ScaffoldColumn(true),Display(Name="Bldg #")]
        [Key, Column(Order = 1)]
        public virtual int NUM { get; set; }
        [ScaffoldColumn(false)]
        [Column("SITUS")]
        public string Situs { get; set; }
        [ScaffoldColumn(false)]
        [Column("TYPE")]
        public string Type { get; set; }
        [ScaffoldColumn(false)]
        [Column("STYLE")]
        public string Style { get; set; }

        [Column("BEDS")]
        public int Beds { get; set; }
        [Column("BATHS")]
        public int Baths { get; set; }

        [Column("HALF_BATHS")]
        public int HalfBaths { get; set; }

        [ScaffoldColumn(false)]
        public int ROOMS { get; set; }
        [ScaffoldColumn(false)]
        [Column("LIVING_UNITS")]
        public int LivingUnits { get; set; }
        //public string CLASS { get; set; }

        [Display(Name = "Year Built")]
        public int? YEAR_BUILT { get; set; }

        [Display(Name = "Gross Area"), DisplayFormat(DataFormatString = "{0:N0}")]
        public int? GROSS_AREA { get; set; }
        [Display(Name = "Living Area"), DisplayFormat(DataFormatString = "{0:N0}")]
        public int? LIVING_AREA { get; set; }

        [Column("STORY_NUM")]
        public int Stories { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey("Strap,BuildingNumber")]
        public virtual ICollection<StructuralElement> StructuralElements { get; set; }
        [ScaffoldColumn(false)]
        [ForeignKey("Strap,BuildingNumber")]
        public virtual ICollection<SubArea> SubAreas { get; set; }


        [ScaffoldColumn(false)] 
        public Parcel Parcel { get; set; }


    }
}