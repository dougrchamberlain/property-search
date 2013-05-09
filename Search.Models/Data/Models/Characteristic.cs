using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("CHARACTERISTICS")]
    public class Characteristic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string STRAP { get; set; }
        public string CAT_CD { get; set; }
        public string TP { get; set; }
        public string CAT { get; set; }
        public string DSCR { get; set; }
    }
}