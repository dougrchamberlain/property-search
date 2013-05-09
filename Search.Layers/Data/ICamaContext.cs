using System;
using System.Linq;
using System.Data.Entity;
using Search.Data.Models;
using Ninject;
using Search.Data;

namespace Search.Data
{
    public interface ICamaContext
    {
        DbSet<Parcel> Parcels { get; set; }
        DbSet<Owner> Owners { get; set; }
        DbSet<Characteristic> Characteristics { get; set; }
        DbSet<Building> Buildings { get; set; }
        DbSet<ExtraFeature> ExtraFeatures { get; set; }
        DbSet<Transfer> Transfers { get; set; }

        DbSet<StructuralElement> StructuralElements { get; set; }
        DbSet<Exemption> Exemptions { get; set; }
        DbSet<SubArea> SubAreas { get; set; }

        DbSet<ParcelValuation> ParcelValuations { get; set; }
        DbSet<AdValorem> AdValorems {get;set;}
        DbSet<NonAdValorem> NonAdValorems { get; set; }

        DbSet<Tangible> TangibleProperties { get; set; }

        DbSet<DOWNLOAD> SarasotaDownload { get; set; }
    }

  
}

