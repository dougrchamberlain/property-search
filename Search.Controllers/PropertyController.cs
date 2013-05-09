// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyController.cs" company="">
//   
// </copyright>
// <summary>
//   The parcel controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Search.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using AutoMapper;

    using LinqKit;

    using LINQtoCSV;

    using Ninject;

    using PagedList;

    using Search.Components.Html.ViewModels;
    using Search.Data;
    using Search.Data.Models;
    using Search.Data.Services;

    /// <summary>
    /// The parcel controller.
    /// </summary>
    public class ParcelController : Controller
    {
        #region Static Fields

        /// <summary>
        /// The _service.
        /// </summary>
        private static CamaService service;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelController"/> class.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        [Inject]
        public ParcelController(CamaService service)
        {
            ParcelController.service = service;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The buildings.
        /// </summary>
        /// <param name="building">
        /// The building.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        public ViewResult Buildings(Building building)
        {
            building = service.GetBuilding(building);
            var viewModel = new BuildingViewModel();

            Mapper.Map(building, viewModel);

            viewModel.ExtraFeatures = building.Parcel.ExtraFeatures.Where(x => x.BUILDING_NUM == building.NUM).ToList();

            return View(viewModel);
        }

        /// <summary>
        /// The details.
        /// </summary>
        /// <param name="strap">
        /// The strap.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        public ViewResult Details(string strap)
        {
            Parcel parcel = service.GetParcelByExactStrap(strap);

            var viewModel = new ParcelViewModel();
            Mapper.Map(parcel, viewModel);

            // viewModel.TOTAL_GROSS_AREA = parcel.GrossArea();
            // viewModel.TOTAL_LIVING_AREA = parcel.LivingArea();

            // TODO:Change this to use the SITUS from the PARCELS table
            viewModel.SITUS = parcel.SITUS;

            viewModel.DELINEATED_DISTRICT = parcel.DelineatedDistrict();

            viewModel.ExtraFeatures = parcel.ExtraFeatures.Where(p => p.BUILDING_NUM == 0).ToList();

            return View(viewModel);
        }

        /// <summary>
        /// The export.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public FilePathResult Export()
        {
            var x = service.GetDownloads(); 
            var expression = (Expression<Func<Parcel, bool>>)TempData["filter"];


            var query = service.GetAllParcels().AsQueryable<Parcel>().Where(expression.Expand());


            var exportitems = query.Join(x, o => o.STRAP, i => i.id.Replace("-",""), (p, d) => d).AsExpandable();



            var fileGuid = Guid.NewGuid();
            var ms = new FileStream("Export_" + fileGuid + ".csv", FileMode.CreateNew);
            TextWriter txt = new StreamWriter(ms);

            var inputFileDescription = new CsvFileDescription
                                           {
                                               SeparatorChar = ',', 
                                               FirstLineHasColumnNames = true, 
                                               QuoteAllFields = true,
                                           };

            var csv = new CsvContext();

            csv.Write(exportitems, txt, inputFileDescription);

            txt.Flush();
            ms.Position = 0;
            txt.Close();
            ms.Close();


            return this.File(ms.Name, "text/csv","Export.csv");
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Search(SearchViewModel model)
        {
            Expression<Func<Parcel, bool>> filterexpression = PredicateBuilder.True<Parcel>();

            this.TryUpdateModel(model);

            IQueryable<Parcel> query = service.GetAllParcels().AsQueryable();

            if (model == null)
            {
                model = new SearchViewModel();
            }

            // TODO: add conditions to only include expressions that have values
            if (model.ParcelSearch.Strap != null)
            {
                filterexpression = filterexpression.And(service.StrapStartsWith(model.ParcelSearch.Strap.AsStrap()));
            }

            if (model.ParcelSearch.OwnerKeywords != null)
            {
                filterexpression = filterexpression.And(service.ContainsInOwnerName(model.ParcelSearch.OwnerKeywords));
            }

            if (model.ParcelSearch.AddressKeywords != null)
            {
                filterexpression = filterexpression.And(service.ContainsInAddress(model.ParcelSearch.AddressKeywords));
            }

            if (model.ParcelSearch.ZipCode != null)
            {

                filterexpression = filterexpression.And(service.LocatedWithinZipCode(model.ParcelSearch.ZipCode));
            }


            // TODO: add boolean conditions. no need to check these for nulls ATM.
            filterexpression =
                filterexpression.Expand()
                                .And(service.HasDock(model.PropertyFeatureSearch.Dock))
                                .And(service.HasPool(model.PropertyFeatureSearch.Pool))
                                .And(service.HasSeaWall(model.PropertyFeatureSearch.SeaWall))
                                .And(service.HasTennisCourt(model.PropertyFeatureSearch.Tennis))
                                .And(service.IsVacant(model.PropertyFeatureSearch.VacantLand))
                                .And(service.IsNew(model.PropertyFeatureSearch.StatusNew))
                                .Expand();

            if (model.SalesSearch.SalesFrom != null && model.SalesSearch.SalesTo != null)
            {
                filterexpression = filterexpression.And(service.SalesInRange(model.SalesSearch.SalesFrom.Value, model.SalesSearch.SalesTo.Value));
            }

            if (model.SalesSearch.SaleAmountFrom != null && model.SalesSearch.SaleAmountTo != null)
            {
                filterexpression =
                    filterexpression.And(service.SalesAmountInRange(model.SalesSearch.SaleAmountFrom, model.SalesSearch.SaleAmountTo)).Expand();
            }

            if (model.SalesSearch.InstrumentNumber != null)
            {
                filterexpression =
                    filterexpression.And(service.SalesWithInstrumentNumber(model.SalesSearch.InstrumentNumber));
            }

            if (model.SalesSearch.GrantorSeller != null)
            {
                filterexpression = filterexpression.And(service.GrantorSellerContains(model.SalesSearch.GrantorSeller));
            }



            // TODO:CREATE SEARCHING HERE
            query = query.Where(filterexpression.Expand());

            this.TempData["filter"] = filterexpression;

            this.ViewData["count"] = query.Count();

            IQueryable<ParcelResultItemViewModel> output =
                query.Select(
                    x =>
                    new ParcelResultItemViewModel
                        {
                            STRAP = x.STRAP, 
                            OWNERS = (List<Owner>)x.Owners, 
                            SITUS = x.SITUS, 
                            SUBDIVISION_PROPERTY_USE = x.PROPERTY_USE, 
                            Status = x.Status, 
                            Pool = x.ExtraFeatures.Any(xfob => xfob.CD == "POOL"),
                            LastUpdated = x.LastUpdated 
                            
                        }).OrderByDescending(x=>x.LastUpdated).Take(500);

            var timer = new Stopwatch();

            timer.Start();

            int page = model.Page ?? 1;
            if ((int)this.ViewData["count"] < page * 10)
            {
                page = 1;
            }

            model.SearchResults = new PagedList<ParcelResultItemViewModel>(output, page, 10);
            timer.Stop();
            Debug.Assert(timer.Elapsed.TotalSeconds.CompareTo(10) < 0,"Query exceeded a reasonable amount of time");
            Debug.Print(timer.Elapsed.TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (model.UseAdvancedSearch)
            {
                return this.View("AdvancedSearch", model);
            }

            return this.View(model);
        }


        /// <summary>
        /// The search by ranges.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [ChildActionOnly]
        public PartialViewResult SearchByRanges()
        {
            return this.PartialView();
        }

        #endregion
    }
}