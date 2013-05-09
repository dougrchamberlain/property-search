using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
using System.Linq.Expressions;
using LinqKit;
using LINQtoCSV;  

namespace Search.Data.Models
{


    #region WEB Objects
   
    [Table("PARCELS")]
    public partial class Parcel : IEquatable<Parcel>,IEqualityComparer<Parcel>
    {
       
        [Key]
        [CsvColumn(OutputFormat= "Text")] 
        public string STRAP { get; set; }
        //public string PROPERTY_ID {get;set;}
        public string SITUS { get; set; }
        public string ZIP_CODE { get; set; }
        public string MAILING_ADDRESS { get; set; }
        public string PROPERTY_USE { get; set; }
        public string SUBDIVISION { get; set; }
        public int LAND_AREA { get; set; }
        public string INCORPORATION { get; set; }
        public string SEC_TWP_RGE { get; set; }
        public string CENSUS { get; set; }
        public string WATERFRONT { get; set; }
        public string ASSESSMENT_DESCRIPTION { get; set;}
        [Column("MUNICIPALITY_CODE")]
        [StringLength(5)]
        public string MunicipalityCode { get; set; }

        [Column("MUNICIPALITY_NAME")]
        [StringLength(30)]
        public string MunicipalityName { get; set; }

        [Column("POOL_FLAG")]
        public bool HasPool { get; set; }

        [Column("DOCK_FLAG")]
        public bool HasDock { get; set; }

        [Column("SEAWALL_FLAG")]
        public bool HasSeaWall { get; set; }

        [Column("TENNIS_FLAG")]
        public bool HasTennisCourt { get; set; }

        [Column("VACANT_FLAG")]
        public bool IsVacant { get; set; }

        [Column("STATUS")]
        [StringLength(25)]
        public string Status { get; set; }

        [Column("LAST_UPDATED")]
        public DateTime LastUpdated { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<Owner> Owners { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<Characteristic> Characteristics { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<Building> Buildings { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<Transfer> Transfers { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<ExtraFeature> ExtraFeatures { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<Exemption> Exemptions { get; set; }

        [ForeignKey("STRAP")]
        public ICollection<ParcelValuation> ParcelValuations { get; set; }
        
        [ForeignKey("STRAP")]
        public ICollection<AdValorem> AdValorems { get; set; }
        
        [ForeignKey("STRAP")]
        public ICollection<NonAdValorem> NonAdValorems { get; set; }




        public bool Equals(Parcel other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal. 
            return STRAP.Equals(other.STRAP);

        }

        public bool Equals(Parcel x, Parcel y)
        {
            return x.STRAP.Equals(y.STRAP);
        }

        public int GetHashCode(Parcel obj)
        {
            return obj.STRAP.GetHashCode(); 
        }
    }

#endregion

}
