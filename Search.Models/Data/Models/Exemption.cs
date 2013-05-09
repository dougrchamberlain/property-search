using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("EXEMPTIONS")]
    public class Exemption
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public string STRAP { get; set; }
        [ScaffoldColumn(false)]
        public int NUM { get; set; }
        [ScaffoldColumn(false)]
        public string CD { get; set; }
        [ScaffoldColumn(false)]
        public DateTime GRANT_DATE { get; set; }

        [Display(Name="Description")] 
        public string DSCR { get; set; }

        [Display(Name="Value"),DisplayFormat(DataFormatString="{0:C0}")]
        public string VALUE { get; set; }
    }
}