using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Search.Data.Services;
using Search.Components.Html.ViewModels;
using Search.Data.Models ; 
using AutoMapper;
using LINQtoCSV;
using System.Linq;
using Search.Data;
using System.Linq.Expressions;

namespace Search.Controllers
{
    public class TangibleController : Controller
    {
        ICamaService _service = null;

        [Inject]
        public TangibleController(ICamaService service)
        {

            _service = service;
        }

        public ActionResult Search(TangibleSearchViewModel Model)
        {
            if (Model == null)
            {
                Model = new TangibleSearchViewModel();

            }

            var results = new List<Tangible>();



            Model.SearchResults = new List<TangibleResultItemViewModel>();
            Mapper.Map(results.Distinct().Take(1500).ToList(), Model.SearchResults);
            return View(Model);

        }


        public ViewResult Details(string id)
        {
            var tangible = new Tangible();

            return View(tangible);
        }

    }
}
