// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The search view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using PagedList;

namespace Search.Components.Html.ViewModels
{
    /// <summary>
    /// The search view model.
    /// </summary>
    public class SearchViewModel
    {

        public SearchViewModel()
        {

            BuildingSearch = new SearchBuildingViewModel();
            ParcelSearch = new SearchParcelViewModel();
            SalesSearch = new SearchSalesViewModel();
            PropertyFeatureSearch = new SearchPropertyFeaturesViewModel();
            ValuesSearch = new SearchValuesViewModel();
        } 

        /// <summary>
        /// Gets or sets a value indicating whether use advanced search.
        /// </summary>
        public bool UseAdvancedSearch { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        [HiddenInput]
        [ScaffoldColumn(false)]
        public int? Page { get; set; }

        #region Search View Models

        /// <summary>
        /// Gets or sets the building search.
        /// </summary>
        public SearchBuildingViewModel BuildingSearch { get; set; }

        /// <summary>
        /// Gets or sets the parcel search.
        /// </summary>
        public SearchParcelViewModel ParcelSearch { get; set; }

        /// <summary>
        /// Gets or sets the property feature search.
        /// </summary>
        public SearchPropertyFeaturesViewModel PropertyFeatureSearch { get; set; }

        /// <summary>
        /// Gets or sets the sales search.
        /// </summary>
        public SearchSalesViewModel SalesSearch { get; set; }

        /// <summary>
        /// Gets or sets the values search.
        /// </summary>
        public SearchValuesViewModel ValuesSearch { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the search results.
        /// </summary>
        [ScaffoldColumn(false)]
        public PagedList<ParcelResultItemViewModel> SearchResults { get; set; }
    }
}