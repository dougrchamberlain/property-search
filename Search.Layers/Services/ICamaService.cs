using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Search.Data.Models;
using System.Linq.Expressions;
using System.Collections;

namespace Search.Data.Services
{


    public interface ICamaService
    {

        #region ParcelExpressions

            Parcel GetParcelByExactStrap(string Strap);
            IEnumerable<Parcel> GetAllParcels();
            Expression<Func<Parcel, bool>> GetParcel(string strap);
            Expression<Func<Parcel, bool>> StrapStartsWith(string value);
            Expression<Func<Parcel, bool>> AssessedRange(int? low, int? high);
            Expression<Func<Parcel, bool>> JustRange(int? low, int? high);
            Expression<Func<Parcel, bool>> TaxableRange(int? low, int? high);
            Expression<Func<Parcel, bool>> LandValueRange(int? low, int? high);
            Expression<Func<Parcel, bool>> ImprovementValueRange(int? low, int? high);
            Expression<Func<Parcel, bool>> isOnBay(bool include);
            Expression<Func<Parcel, bool>> isOnCanal(bool include);
            Expression<Func<Parcel, bool>> isOnGulf(bool include);
            Expression<Func<Parcel, bool>> isNotOnNavigableWater(bool include);
            Expression<Func<Parcel, bool>> ContainsInAddress(params string[] keywords);
            Expression<Func<Parcel, bool>> LocatedWithinZipCode(params string[] keywords);
            Expression<Func<Parcel, bool>> LocatedWithinSubdivisions(params string[] keywords);
            Expression<Func<Parcel, bool>> LocatedWithinMunicipalities(params string[] keywords);
            Expression<Func<Parcel, bool>> ContainsInUseCode(params string[] keywords);
            Expression<Func<Parcel, bool>> ContainsInZoning(params string[] keywords);
            Expression<Func<Parcel, bool>> ContainsInExemptions(params string[] keywords);
            Expression<Func<Parcel, bool>> LandAreaRange(int? low, int? high);
            Expression<Func<Parcel, bool>> IsVacant(bool include);
            Expression<Func<Parcel, bool>> HasPool(bool include);
            Expression<Func<Parcel, bool>> HasTennisCourt(bool include);
            Expression<Func<Parcel, bool>> HasSeaWall(bool include);
            Expression<Func<Parcel, bool>> HasDock(bool include);
            Expression<Func<Parcel, bool>> IsPrivate(bool include);
        #endregion

            #region BuildingExpressions
            Building GetBuilding(Building building);
            Building GetBuilding(int BuildingNumber);
            Expression<Func<Parcel, bool>> YearBuiltRange(int? low, int? high);
            Expression<Func<Parcel, bool>> GrossAreaRange(int? low, int? high);
            Expression<Func<Parcel, bool>> LivingAreaRange(int? low, int? high);
            Expression<Func<Parcel, bool>> StoriesRange(int? low, int? high);
            Expression<Func<Parcel, bool>> UnitsRange(int? low, int? high);
            Expression<Func<Parcel, bool>> BedroomsRange(int? low, int? high);
            Expression<Func<Parcel, bool>> BathroomsRange(int? low, int? high);
            #endregion

            #region SalesExpressions
            Expression<Func<Parcel, bool>> SalesInRange(DateTime date1, DateTime date2);
            Expression<Func<Parcel, bool>> SalesAmountInRange(int? low, int? high);
            Expression<Func<Parcel, bool>> SalesWithInstrumentNumber(string value);
            [Obsolete]
            Expression<Func<Parcel, bool>> SalesWithInstrumentType(string value);
            Expression<Func<Parcel, bool>> GrantorSellerContains(params string[] keywords);
            #endregion

            IEnumerable<KeyValuePair<String, String>> GetMunicipalities();
            IEnumerable<KeyValuePair<String, String>> GetUseCodes();
            IEnumerable<KeyValuePair<String, String>> GetZoningCodes();
            IEnumerable<KeyValuePair<String, String>> GetSubdivisions();
            IEnumerable<KeyValuePair<String, String>> GetExemptions();
            IEnumerable<KeyValuePair<String, String>> GetLotBlockSubs();
            IEnumerable<KeyValuePair<String, String>> GetSecTownRanges();



             Expression<Func<Parcel, bool>> ContainsInOwnerName(params string[] keywords);
             IEnumerable<Parcel> ExportParcelData();


    }

}
