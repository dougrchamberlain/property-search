using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{

    [Table("SUB_AREAS")]
    public class SubArea
    {

        [Key,ScaffoldColumn(false)]
        [Column("STRAP",Order = 0)]
        public virtual string Strap { get; set; }
        [Key,Display(Name="Bldg #")]
        [ScaffoldColumn(false)]
        [Column("BUILDING_NUM",Order = 1)]
        public virtual int BuildingNumber { get; set; }
        [ScaffoldColumn(true),Display(Name="line #")]
        [Key]
        [Column(Order = 2)]
        public int LN_NUM { get; set; }
        [Key]
        [Column(Order = 3),ScaffoldColumn(false)]
        public string CD { get; set; }

        [Display(Name="Description")]
        public string DSCR { get; set; }
        [Display(Name="Gross Area"),DisplayFormat(DataFormatString="{0:N0}")]
        public int GROSS_AREA { get; set; }
        [ScaffoldColumn(false)]
        public int VALUE { get; set; }
    }
}