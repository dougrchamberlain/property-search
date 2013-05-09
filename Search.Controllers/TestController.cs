using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Search.Data.Services;
using Ninject; 

namespace Search.Controllers
{
    public class TestController : Controller
    {
         ICamaService _service = null;

        [Inject]
         public TestController(ICamaService service)
        {
            _service = service;
        }



        public ActionResult Index()
        {
            var parcel = _service.GetParcelByExactStrap("0001-02-0003");

 
            return View(parcel);
        }

    }
}
