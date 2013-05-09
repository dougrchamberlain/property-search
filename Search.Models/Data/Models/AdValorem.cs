using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("AD_VALOREMS")]
    public class AdValorem
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AV_ID { get; set; }
        [ScaffoldColumn(false)]
        public string STRAP { get; set; }
        [Display(Name = "Code")]
        public string CODE { get; set; }
        [Display(Name = "Description")]
        public string DSCR { get; set; }
        [Display(Name = "Millage Rate")]
        public decimal MILL_RATE { get; set; }

    }
}