using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("NON_AD_VALOREMS")]
    public class NonAdValorem
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NAV_ID { get; set; }
        [ScaffoldColumn(false)]
        public string STRAP { get; set; }
        [Display(Name="Code")]
        public string CODE { get; set; }
        [Display(Name = "Description")]
        public string DSCR { get; set; }
    }
}