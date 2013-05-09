using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{

    [Table("STRUCTURAL_ELEMENTS")]
    public class StructuralElement
    {
        [ScaffoldColumn(false)]
        [Key, Column("STRAP", Order = 0)]
        public virtual string Strap { get; set; }

        [ScaffoldColumn(false)]
        [Key, Column("BUILDING_NUM", Order = 1)]
        public virtual int BuildingNumber { get; set; }

        [Display(Name = "Line #", Order = 0)]
        [Key, Column("LN_NUM", Order = 2)]
        public int LineNumber { get; set; }


        [Display(Name = "Category", Order = 1), ScaffoldColumn(false)]
        [Key, Column("CATEGORY", Order = 3)]
        public string Category { get; set; }

        [Display(Name = "Description", ShortName = "Descrip.", Order = 1)]
        [Column("DSCR")]
        public string Description { get; set; }

        [Display(Name = "Value", Order = 2),DisplayFormat(DataFormatString="{0:C0}")]
        [Column("VALUE")]
        public string Value { get; set; }

    }
}