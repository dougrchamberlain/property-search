using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search.Data.Models
{
    [Table("TANGIBLE")]
    public class Tangible
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]        
        public int ID { get; set; }

        [Column("ACCOUNT_NUMBER")] 
        public string AccountNumber { get; set; }

        [Column("PROPERTY_ADDRESS")]
        public string PropertyAddress { get; set; }

        [Column("STRAP")]
        public string AssociatedStrap { get; set; }

        [Column("OWNER_NAME")]
        public string OwnerName { get; set; }

        [Column("BUSINESS_TYPE")]
        public string BusinessType { get; set; }

        [Column("LOCAL_TAX_NO")]
        public string LocalTaxId { get; set; }

        [Column("MAILING_ADDRESS")]
        public string MailingAddress { get; set; }

        [Column("LAST_RETURN_FILED") ]
        public DateTime LastReturnFiled { get; set; }

        [Column("WAIVED_FLAG")]
        public bool IsWaived { get; set; }


    }
}
