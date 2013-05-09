using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Search.Data.Models
{
    [Table("EXTRA_FEATURES")]
    public class ExtraFeature
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        [ScaffoldColumn(false)]
        public string STRAP { get; private set; }
        [Display(Name = "Building Number", ShortName = "Bld #", GroupName = "Extra Features", Prompt = "Building Number", Description = "Building Number for this Extra Feature")]
        [ScaffoldColumn(false)]
        public int BUILDING_NUM { get; private set;}
        
        [Display(Name="line #",Order=0)]
        public int LN_NUM { get; private set; }
        
        [Display(Name = "Description", ShortName = "Dscr", Prompt = "Extra Feature Description", Description = "Description for this Extra Feature",Order=1)]        
        public string DSCR { get;  private set; }
        
        
        [Display(Name="Units",ShortName="Uts",Description="Number of Units for this Extra Feature",Prompt="Enter Number of Units",Order=2),DisplayFormat(DataFormatString = "{0:G}")]        
        public decimal? UNITS { get; private set; }
        
        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]          
        public decimal? UNIT_PRICE { get;private set; }
        
        [Display(Name = "Year", Description = "This is the year the extra feature was added to the parcel.",Order=4)]        
        public int? YEAR_BUILT { get; private set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Code", ShortName = "CD", Prompt = "Extra Feature Code", Description = "Code for this Extra Feature")]
        public string CD { get; private set; }
        [Display(Name = "Unit Type",Order=3)]
        public string UNIT_TYPE { get; private set; }

    }
}