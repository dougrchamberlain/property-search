// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DOWNLOAD.cs" company="">
//   
// </copyright>
// <summary>
//   The download.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Search.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using LINQtoCSV;

    /// <summary>
    /// The download.
    /// </summary>
    [Table("DOWNLOADS")]
    public class DOWNLOAD
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the block.
        /// </summary>
        [CsvColumn(FieldIndex = 25)]
        public string BLOCK { get; set; }

        /// <summary>
        /// Gets or sets the pool.
        /// </summary>
        [CsvColumn(FieldIndex = 220)]
        public string POOL { get; set; }

        /// <summary>
        /// Gets or sets the assd.
        /// </summary>
        [CsvColumn(FieldIndex = 30)]
        public decimal? assd { get; set; }

        /// <summary>
        /// Gets or sets the bath.
        /// </summary>
        [CsvColumn(FieldIndex = 280)]
        public int? bath { get; set; }

        /// <summary>
        /// Gets or sets the bedr.
        /// </summary>
        [CsvColumn(FieldIndex = 270)]
        public int? bedr { get; set; }

        /// <summary>
        /// Gets or sets the build_clas.
        /// </summary>
        [CsvColumn(FieldIndex = 240)]
        public string build_clas { get; set; }

        /// <summary>
        /// Gets or sets the census.
        /// </summary>
        [CsvColumn(FieldIndex = 28)]
        public string census { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [CsvColumn(FieldIndex = 6)]
        public string city { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [CsvColumn(FieldIndex = 9)]
        public string country { get; set; }

        /// <summary>
        /// Gets or sets the del_area.
        /// </summary>
        [CsvColumn(FieldIndex = 21)]
        public string del_area { get; set; }

        /// <summary>
        /// Gets or sets the exempt 1.
        /// </summary>
        [CsvColumn(FieldIndex = 80)]
        public short? exempt1 { get; set; }

        /// <summary>
        /// Gets or sets the exempt 2.
        /// </summary>
        [CsvColumn(FieldIndex = 90)]
        public short? exempt2 { get; set; }

        /// <summary>
        /// Gets or sets the exempt 3.
        /// </summary>
        [CsvColumn(FieldIndex = 100)]
        public short? exempt3 { get; set; }

        /// <summary>
        /// Gets or sets the exempt 4.
        /// </summary>
        [CsvColumn(FieldIndex = 110)]
        public short? exempt4 { get; set; }

        /// <summary>
        /// Gets or sets the exempt 5.
        /// </summary>
        [CsvColumn(FieldIndex = 120)]
        public short? exempt5 { get; set; }

        /// <summary>
        /// Gets or sets the exemptions.
        /// </summary>
        [CsvColumn(FieldIndex = 50)]
        public decimal? exemptions { get; set; }

        /// <summary>
        /// Gets or sets the grnd_area.
        /// </summary>
        [CsvColumn(FieldIndex = 250)]
        public int? grnd_area { get; set; }

        /// <summary>
        /// Gets or sets the gulfbay.
        /// </summary>
        [CsvColumn(FieldIndex = 27)]
        public string gulfbay { get; set; }

        /// <summary>
        /// Gets or sets the halfbath.
        /// </summary>
        [CsvColumn(FieldIndex = 290)]
        public int? halfbath { get; set; }

        /// <summary>
        /// Gets or sets the homestead.
        /// </summary>
        [CsvColumn(FieldIndex = 60)]
        public string homestead { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [CsvColumn(FieldIndex = 0)]
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the improvemt.
        /// </summary>
        [CsvColumn(FieldIndex = 70)]
        public decimal? improvemt { get; set; }

        /// <summary>
        /// Gets or sets the just.
        /// </summary>
        [CsvColumn(FieldIndex = 29)]
        public decimal? just { get; set; }

        /// <summary>
        /// Gets or sets the legal 1.
        /// </summary>
        [CsvColumn(FieldIndex = 320)]
        public string legal1 { get; set; }

        /// <summary>
        /// Gets or sets the legal 2.
        /// </summary>
        [CsvColumn(FieldIndex = 330)]
        public string legal2 { get; set; }

        /// <summary>
        /// Gets or sets the legal 3.
        /// </summary>
        [CsvColumn(FieldIndex = 340)]
        public string legal3 { get; set; }

        /// <summary>
        /// Gets or sets the legal 4.
        /// </summary>
        [CsvColumn(FieldIndex = 350)]
        public string legal4 { get; set; }

        /// <summary>
        /// Gets or sets the legalrefer.
        /// </summary>
        [CsvColumn(FieldIndex = 210)]
        public string legalrefer { get; set; }

        /// <summary>
        /// Gets or sets the living.
        /// </summary>
        [CsvColumn(FieldIndex = 260)]
        public int? living { get; set; }

        /// <summary>
        /// Gets or sets the livunits.
        /// </summary>
        [CsvColumn(FieldIndex = 300)]
        public int? livunits { get; set; }

        /// <summary>
        /// Gets or sets the lnvs_n.
        /// </summary>
        [CsvColumn(FieldIndex = 130)]
        public decimal? lnvs_n { get; set; }

        /// <summary>
        /// Gets or sets the loccity.
        /// </summary>
        [CsvColumn(FieldIndex = 14)]
        public string loccity { get; set; }

        /// <summary>
        /// Gets or sets the locd.
        /// </summary>
        [CsvColumn(FieldIndex = 12)]
        public string locd { get; set; }

        /// <summary>
        /// Gets or sets the locn.
        /// </summary>
        [CsvColumn(FieldIndex = 10)]
        public string locn { get; set; }

        /// <summary>
        /// Gets or sets the locs.
        /// </summary>
        [CsvColumn(FieldIndex = 11)]
        public string locs { get; set; }

        /// <summary>
        /// Gets or sets the locstate.
        /// </summary>
        [CsvColumn(FieldIndex = 15)]
        public string locstate { get; set; }

        /// <summary>
        /// Gets or sets the loczip.
        /// </summary>
        [CsvColumn(FieldIndex = 16)]
        public string loczip { get; set; }

        /// <summary>
        /// Gets or sets the lot.
        /// </summary>
        [CsvColumn(FieldIndex = 26)]
        public string lot { get; set; }

        /// <summary>
        /// Gets or sets the lsqft.
        /// </summary>
        [CsvColumn(FieldIndex = 360)]
        public int? lsqft { get; set; }

        /// <summary>
        /// Gets or sets the name 1.
        /// </summary>
        [CsvColumn(FieldIndex = 1)]
        public string name1 { get; set; }

        /// <summary>
        /// Gets or sets the name_add 2.
        /// </summary>
        [CsvColumn(FieldIndex = 2)]
        public string name_add2 { get; set; }

        /// <summary>
        /// Gets or sets the name_add 3.
        /// </summary>
        [CsvColumn(FieldIndex = 3)]
        public string name_add3 { get; set; }

        /// <summary>
        /// Gets or sets the name_add 4.
        /// </summary>
        [CsvColumn(FieldIndex = 4)]
        public string name_add4 { get; set; }

        /// <summary>
        /// Gets or sets the name_add 5.
        /// </summary>
        [CsvColumn(FieldIndex = 5)]
        public string name_add5 { get; set; }

        /// <summary>
        /// Gets or sets the nghb.
        /// </summary>
        [CsvColumn(FieldIndex = 18)]
        public string nghb { get; set; }

        /// <summary>
        /// Gets or sets the or_book.
        /// </summary>
        [CsvColumn(FieldIndex = 190)]
        public string or_book { get; set; }

        /// <summary>
        /// Gets or sets the or_page.
        /// </summary>
        [CsvColumn(FieldIndex = 200)]
        public string or_page { get; set; }

        /// <summary>
        /// Gets or sets the pool_built.
        /// </summary>
        [CsvColumn(FieldIndex = 230)]
        public int? pool_built { get; set; }

        /// <summary>
        /// Gets or sets the qual_code.
        /// </summary>
        [CsvColumn(FieldIndex = 180)]
        public string qual_code { get; set; }

        /// <summary>
        /// Gets or sets the rang.
        /// </summary>
        [CsvColumn(FieldIndex = 24)]
        public string rang { get; set; }

        /// <summary>
        /// Gets or sets the sale_amt.
        /// </summary>
        [CsvColumn(FieldIndex = 160)]
        public decimal? sale_amt { get; set; }

        /// <summary>
        /// Gets or sets the sale_date.
        /// </summary>
        [CsvColumn(FieldIndex = 170)]
        public string sale_date { get; set; }

        /// <summary>
        /// Gets or sets the sect.
        /// </summary>
        [CsvColumn(FieldIndex = 22)]
        public string sect { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [CsvColumn(FieldIndex = 7)]
        public string state { get; set; }

        /// <summary>
        /// Gets or sets the stcd.
        /// </summary>
        [CsvColumn(FieldIndex = 17)]
        public string stcd { get; set; }

        /// <summary>
        /// Gets or sets the subd.
        /// </summary>
        [CsvColumn(FieldIndex = 19)]
        public string subd { get; set; }

        /// <summary>
        /// Gets or sets the twsp.
        /// </summary>
        [CsvColumn(FieldIndex = 23)]
        public string twsp { get; set; }

        /// <summary>
        /// Gets or sets the txbl.
        /// </summary>
        [CsvColumn(FieldIndex = 40)]
        public decimal? txbl { get; set; }

        /// <summary>
        /// Gets or sets the txcd.
        /// </summary>
        [CsvColumn(FieldIndex = 20)]
        public string txcd { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        [CsvColumn(FieldIndex = 13)]
        public string unit { get; set; }

        /// <summary>
        /// Gets or sets the yrbl.
        /// </summary>
        [CsvColumn(FieldIndex = 310)]
        public int? yrbl { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        [CsvColumn(FieldIndex = 8)]
        public string zip { get; set; }

        /// <summary>
        /// Gets or sets the zoning_1.
        /// </summary>
        [CsvColumn(FieldIndex = 140)]
        public string zoning_1 { get; set; }

        /// <summary>
        /// Gets or sets the zoning_2.
        /// </summary>
        [CsvColumn(FieldIndex = 150)]
        public string zoning_2 { get; set; }

        #endregion
    }
}