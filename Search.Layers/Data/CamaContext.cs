// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CamaContext.cs" company="">
//   
// </copyright>
// <summary>
//   The cama context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Search.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Search.Data.Models;

    /// <summary>
    /// The cama context.
    /// </summary>
    public class CamaContext : DbContext, ICamaContext
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CamaContext"/> class.
        /// </summary>
        public CamaContext()
            : base("CamaContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 3000;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the ad valorems.
        /// </summary>
        public DbSet<AdValorem> AdValorems { get; set; }

        /// <summary>
        /// Gets or sets the buildings.
        /// </summary>
        public DbSet<Building> Buildings { get; set; }

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        public DbSet<Characteristic> Characteristics { get; set; }

        /// <summary>
        /// Gets or sets the exemptions.
        /// </summary>
        public DbSet<Exemption> Exemptions { get; set; }

        /// <summary>
        /// Gets or sets the extra features.
        /// </summary>
        public DbSet<ExtraFeature> ExtraFeatures { get; set; }

        /// <summary>
        /// Gets or sets the non ad valorems.
        /// </summary>
        public DbSet<NonAdValorem> NonAdValorems { get; set; }

        /// <summary>
        /// Gets or sets the owners.
        /// </summary>
        public DbSet<Owner> Owners { get; set; }

        /// <summary>
        /// Gets or sets the parcel valuations.
        /// </summary>
        public DbSet<ParcelValuation> ParcelValuations { get; set; }

        /// <summary>
        /// Gets or sets the parcels.
        /// </summary>
        public DbSet<Parcel> Parcels { get; set; }

        /// <summary>
        /// Gets or sets the structural elements.
        /// </summary>
        public DbSet<StructuralElement> StructuralElements { get; set; }

        /// <summary>
        /// Gets or sets the sub areas.
        /// </summary>
        public DbSet<SubArea> SubAreas { get; set; }

        /// <summary>
        /// Gets or sets the tangible properties.
        /// </summary>
        public DbSet<Tangible> TangibleProperties { get; set; }

        /// <summary>
        /// Gets or sets the transfers.
        /// </summary>
        public DbSet<Transfer> Transfers { get; set; }

        public DbSet<DOWNLOAD> SarasotaDownload { get; set; }

        #endregion
    }
}