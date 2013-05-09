using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("OWNERS")]
    public class Owner
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        public string STRAP { get; set; }
        [ScaffoldColumn(false)]
        public int LN_NUM { get; set; }
        [Display(Name="Owner")]
        [StringLength(100)]
        public string NAME { get; set; }

    }
}