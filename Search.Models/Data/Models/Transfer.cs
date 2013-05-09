using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Search.Data.Models
{
    [Table("TRANSFERS")]
    public class Transfer
    {
        [ScaffoldColumn(false)] 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ScaffoldColumn(false)] 
        public string STRAP { get; set; }
        
        [Display(Name="Transfer Date"),DataType(DataType.Date)]
        public DateTime TRANS_DATE { get; set; }
        
        [Display(Name="Recorded Transaction"),DisplayFormat(DataFormatString="{0:C0}") ]
        public int AMOUNT { get; set; }

        [Display(Name="Instrument Number")]
        public string INSTRUMENT_NUM { get; set; }

        [Display(Name = "Qualification Code")]
        public string TRANS_CODE { get; set; }


        [Display(Name = "Grantor/Seller")]
        public string GRANTOR { get; set; }

        [Display(Name = "Instrument Type")]
        public string INSTRUMENT_TYPE { get; set; }

    }
}