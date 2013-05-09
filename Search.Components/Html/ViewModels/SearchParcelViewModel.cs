// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchParcelViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The search parcel view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Search.Components.Html.ViewModels
{
    /// <summary>
    ///     The search parcel view model.
    /// </summary>
    public class SearchParcelViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the address keywords.
        /// </summary>
        public string AddressKeywords { get; set; }

        /// <summary>
        ///     Gets or sets the census.
        /// </summary>
        public string Census { get; set; }

        /// <summary>
        ///     Gets or sets the lot block sub.
        /// </summary>
        public string LotBlockSub { get; set; }

        /// <summary>
        ///     Gets or sets the owner keywords.
        /// </summary>
        public string OwnerKeywords { get; set; }

        /// <summary>
        ///     Gets or sets the section township range.
        /// </summary>
        public string SectionTownshipRange { get; set; }

        /// <summary>
        ///     Gets or sets the strap.
        /// </summary>
        public string Strap { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        #endregion
    }
}