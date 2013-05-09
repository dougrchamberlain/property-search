// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParcelService.cs" company="">
//   
// </copyright>
// <summary>
//   The cama service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Search.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using LinqKit;

    using Ninject;

    using Search.Data.Models;

    /// <summary>
    /// The cama service.
    /// </summary>
    public class CamaService
    {
        #region Fields

        /// <summary>
        /// The _context.
        /// </summary>
        private readonly ICamaContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CamaService"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        [Inject]
        public CamaService(ICamaContext context)
        {
            this._context = context;

            if (this._context == null)
            {
                throw new InvalidOperationException("Context cannot be null");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The assessed range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> AssessedRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.ParcelValuations.Any(
                        b => (low == null || b.ASSESSED > low) && (high == null || b.ASSESSED <= high))).Expand();
            return predicate;
        }


        /// <summary>
        /// The bathrooms range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Expression<Func<Parcel, bool>> BathroomsRange(int? low, int? high)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The bedrooms range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Expression<Func<Parcel, bool>> BedroomsRange(int? low, int? high)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The contains in address.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> ContainsInAddress(params string[] keywords)
        {
            keywords = keywords.Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();

            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate =
                    predicate.And(p => p.SITUS.Contains(temp) || p.Buildings.Any(b => b.Situs.Contains(temp))).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The contains in exemptions.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Expression<Func<Parcel, bool>> ContainsInExemptions(params string[] keywords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The contains in owner name.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> ContainsInOwnerName(params string[] keywords)
        {
            keywords = keywords.Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();

            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.And(p => p.Owners.Any(o => o.NAME.Contains(temp))).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The contains in use code.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Expression<Func<Parcel, bool>> ContainsInUseCode(params string[] keywords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The contains in zoning.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Expression<Func<Parcel, bool>> ContainsInZoning(params string[] keywords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The export parcel data.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Parcel> ExportParcelData()
        {
            return
                this._context.Parcels.Include(p => p.Owners)
                    .Include(p => p.Transfers)
                    .Include(p => p.Buildings)
                    .Include(p => p.Buildings)
                    .Include(p => p.ParcelValuations)
                    .Include(p => p.ExtraFeatures)
                    .Include(p => p.Exemptions)
                    .AsExpandable();
        }

        public IEnumerable<DOWNLOAD> GetDownloads()
        {
            return this._context.SarasotaDownload.AsExpandable();
        }

        /// <summary>
        /// The get all parcels.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// 
        public IEnumerable<Parcel> GetAllParcels()
        {
            return this._context.Parcels.Include(p => p.Owners).Include(p => p.Transfers).AsExpandable();
        }

        /// <summary>
        /// The get building.
        /// </summary>
        /// <param name="building">
        /// The building.
        /// </param>
        /// <returns>
        /// The <see cref="Building"/>.
        /// </returns>
        public Building GetBuilding(Building building)
        {
            return
                this._context.Buildings.Include(x => x.StructuralElements)
                    .Include(x => x.SubAreas)
                    .Include(x => x.Parcel)
                    .Include(x => x.Parcel.ExtraFeatures)
                    .Where(b => b.STRAP == building.STRAP && b.NUM == building.NUM)
                    .FirstOrDefault();
        }

        /// <summary>
        /// The get building.
        /// </summary>
        /// <param name="BuildingNumber">
        /// The building number.
        /// </param>
        /// <returns>
        /// The <see cref="Building"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Building GetBuilding(int BuildingNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get districts.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<KeyValuePair<string, string>> GetDistricts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get exemptions.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetExemptions()
        {
            var list = new List<KeyValuePair<string, string>>();

            var temp = this._context.Exemptions.Select(p => new { key = p.CD, value = p.DSCR }).Distinct().ToList();

            list.AddRange(temp.Select(p => new KeyValuePair<string, string>(p.key, p.value)));

            return list;
        }

        /// <summary>
        /// The get lot block subs.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<KeyValuePair<string, string>> GetLotBlockSubs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get municipalities.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetMunicipalities()
        {
            var list = new List<KeyValuePair<string, string>>();

            var temp =
                this._context.Parcels.Select(p => new { p.MunicipalityCode, p.MunicipalityName }).Distinct().ToList();

            list.AddRange(temp.Select(p => new KeyValuePair<string, string>(p.MunicipalityCode, p.MunicipalityName)));

            return list;
        }

        /// <summary>
        /// The get parcel.
        /// </summary>
        /// <param name="strap">
        /// The strap.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> GetParcel(string strap)
        {
            return p => p.STRAP == strap;
        }

        /// <summary>
        /// The get parcel by exact strap.
        /// </summary>
        /// <param name="Strap">
        /// The strap.
        /// </param>
        /// <returns>
        /// The <see cref="Parcel"/>.
        /// </returns>
        public Parcel GetParcelByExactStrap(string Strap)
        {
            Strap = Strap.AsStrap();
            return
                this._context.Parcels.Include(p => p.AdValorems)
                    .Include(p => p.Buildings)
                    .Include(p => p.Characteristics)
                    .Include(p => p.Exemptions)
                    .Include(p => p.ExtraFeatures)
                    .Include(p => p.NonAdValorems)
                    .Include(p => p.Owners)
                    .Include(p => p.ParcelValuations)
                    .Include(p => p.Transfers)
                    .Where(x => x.STRAP == Strap)
                    .FirstOrDefault();
        }

        /// <summary>
        /// The get sec town ranges.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<KeyValuePair<string, string>> GetSecTownRanges()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get subdivisions.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetSubdivisions()
        {
            var list = new List<KeyValuePair<string, string>>();

            var temp =
                this._context.Parcels.Select(p => new { key = p.SUBDIVISION, value = p.SUBDIVISION })
                    .Distinct()
                    .ToList();

            list.AddRange(temp.Select(p => new KeyValuePair<string, string>(p.key, p.value)));

            return list;
        }

        /// <summary>
        /// The get taxing authorities.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<KeyValuePair<string, string>> GetTaxingAuthorities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get use codes.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetUseCodes()
        {
            var list = new List<KeyValuePair<string, string>>();

            var temp =
                this._context.Parcels.Select(p => new { key = p.PROPERTY_USE, value = p.PROPERTY_USE })
                    .Distinct()
                    .ToList();

            list.AddRange(temp.Select(p => new KeyValuePair<string, string>(p.key, p.value)));

            return list;
        }

        /// <summary>
        /// The get zoning codes.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<KeyValuePair<string, string>> GetZoningCodes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The grantor seller contains.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> GrantorSellerContains(params string[] keywords)
        {
            keywords = keywords.Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.And(p => p.Transfers.Any(t => t.GRANTOR.Contains(temp))).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The gross area range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> GrossAreaRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.Buildings.Any(b => (low == null || b.GROSS_AREA > low) && (high == null || b.GROSS_AREA <= high)))
                         .Expand();
            return predicate;
        }

        /// <summary>
        /// The has dock.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> HasDock(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.ExtraFeatures.Any(x => x.CD == "DOCK")).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The has pool.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> HasPool(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate =
                    predicate.And(p => p.ExtraFeatures.Any(x => new[] { "SPA", "POOL" }.Contains(x.CD))).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The has sea wall.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> HasSeaWall(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate =
                    predicate.And(
                        p =>
                        p.ExtraFeatures.Any(
                            x => new[] { "SWCCCN", "SWCCGF", "SWCCIC", "SWSTNE", "SWWOOD" }.Contains(x.CD))).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The has tennis court.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> HasTennisCourt(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.ExtraFeatures.Any(x => x.CD == "TENNIS")).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The improvement value range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> ImprovementValueRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.ParcelValuations.Any(
                        b => (low == null || b.BUILDING > low) && (high == null || b.BUILDING <= high))).Expand();
            return predicate;
        }

        /// <summary>
        /// The is new.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> IsNew(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate =
                    predicate.And(
                        p => p.Status.Equals("FUTURE ROLL PENDING") || p.Status.Equals("CURRENT ROLL PENDING")).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The is private.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        [Obsolete]
        public Expression<Func<Parcel, bool>> IsPrivate(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.STRAP == "0001-02-0003").Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The is vacant.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> IsVacant(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.Buildings.Any() == false).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The just range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> JustRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p => p.ParcelValuations.Any(b => (low == null || b.JUST > low) && (high == null || b.JUST <= high)))
                         .Expand();
            return predicate;
        }

        /// <summary>
        /// The land area range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Expression<Func<Parcel, bool>> LandAreaRange(int? low, int? high)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The land value range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> LandValueRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p => p.ParcelValuations.Any(b => (low == null || b.LAND > low) && (high == null || b.LAND <= high)))
                         .Expand();
            return predicate;
        }

        /// <summary>
        /// The living area range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> LivingAreaRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.Buildings.Any(
                        b => (low == null || b.LIVING_AREA > low) && (high == null || b.LIVING_AREA <= high))).Expand();
            return predicate;
        }

        /// <summary>
        /// The located within municipalities.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> LocatedWithinMunicipalities(params string[] keywords)
        {
            keywords = keywords.Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.And(p => keywords.Any(m => p.MunicipalityCode == m)).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The located within subdivisions.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> LocatedWithinSubdivisions(params string[] keywords)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (keywords != null && keywords.Length > 0)
            {
                foreach (string keyword in keywords)
                {
                    string temp = keyword;
                    predicate = predicate.And(p => p.SUBDIVISION.Contains(temp)).Expand();
                }
            }

            return predicate;
        }

        /// <summary>
        /// The located within zip code.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> LocatedWithinZipCode(params string[] keywords)
        {
            keywords = keywords.Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();

            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate =
                    predicate.And(p => p.ZIP_CODE.Contains(temp))
                             .Or(p => p.Buildings.Any(b => b.Situs.Contains(temp)))
                             .Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The sales amount in range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> SalesAmountInRange(int? low, int? high)
        {
            return p => p.Transfers.Any(t => (low == null || t.AMOUNT >= low) && (high == null || t.AMOUNT <= high));
        }

        /// <summary>
        /// The sales in range.
        /// </summary>
        /// <param name="date1">
        /// The date 1.
        /// </param>
        /// <param name="date2">
        /// The date 2.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> SalesInRange(DateTime date1, DateTime date2)
        {
            return
                p =>
                p.Transfers.Any(
                    t =>
                    (t.TRANS_DATE == null || t.TRANS_DATE >= date1) && (t.TRANS_DATE == null || t.TRANS_DATE <= date2));
        }

        /// <summary>
        /// The sales with instrument number.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> SalesWithInstrumentNumber(string value)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate = predicate.And(p => p.Transfers.Any(t => t.INSTRUMENT_NUM.Equals(value))).Expand();
            return predicate;
        }

        /// <summary>
        /// The sales with instrument type.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        [Obsolete]
        public Expression<Func<Parcel, bool>> SalesWithInstrumentType(string value)
        {
            return p => p.Transfers.Any(t => t.INSTRUMENT_TYPE.Equals(value)) || true;
        }

        /// <summary>
        /// The stories range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> StoriesRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p => p.Buildings.Any(b => (low == null || b.Stories > low) && (high == null || b.Stories <= high)))
                         .Expand();
            return predicate;
        }

        /// <summary>
        /// The strap starts with.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> StrapStartsWith(string value)
        {
            return p => p.STRAP.StartsWith(value);
        }

        /// <summary>
        /// The taxable range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> TaxableRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.ParcelValuations.Any(b => (low == null || b.TAXABLE > low) && (high == null || b.TAXABLE <= high)))
                         .Expand();
            return predicate;
        }

        /// <summary>
        /// The units range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> UnitsRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.Buildings.Any(
                        b => (low == null || b.LivingUnits > low) && (high == null || b.LivingUnits <= high))).Expand();
            return predicate;
        }

        /// <summary>
        /// The year built range.
        /// </summary>
        /// <param name="low">
        /// The low.
        /// </param>
        /// <param name="high">
        /// The high.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> YearBuiltRange(int? low, int? high)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            predicate =
                predicate.And(
                    p =>
                    p.Buildings.Any(b => (low == null || b.YEAR_BUILT > low) && (high == null || b.YEAR_BUILT <= high)))
                         .Expand();
            return predicate;
        }

        /// <summary>
        /// The is not on navigable water.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> isNotOnNavigableWater(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.WATERFRONT.Equals("MAIN")).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The is on bay.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> isOnBay(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.WATERFRONT.Equals("BAY")).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The is on canal.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> isOnCanal(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.WATERFRONT.Equals("CANL")).Expand();
            }

            return predicate;
        }

        /// <summary>
        /// The is on gulf.
        /// </summary>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public Expression<Func<Parcel, bool>> isOnGulf(bool include)
        {
            Expression<Func<Parcel, bool>> predicate = PredicateBuilder.True<Parcel>();
            if (include)
            {
                predicate = predicate.And(p => p.WATERFRONT.Equals("GULF")).Expand();
            }

            return predicate;
        }

        #endregion
    }
}