// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchPropertyFeaturesViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The search property features view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Search.Components.Html.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The search property features view model.
    /// </summary>
    public class SearchPropertyFeaturesViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether bay.
        /// </summary>
        public bool Bay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether canal.
        /// </summary>
        public bool Canal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether dock.
        /// </summary>
        public bool Dock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gulf.
        /// </summary>
        public bool Gulf { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether mainland.
        /// </summary>
        public bool Mainland { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether pool.
        /// </summary>
        [Display(Name = "Pool", ShortName = "Pool", Description = "Only properties with a pool")]
        public bool Pool { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether sea wall.
        /// </summary>
        public bool SeaWall { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether status new.
        /// </summary>
        public bool StatusNew { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether tennis.
        /// </summary>
        public bool Tennis { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether vacant land.
        /// </summary>
        public bool VacantLand { get; set; }

        #endregion
    }
}