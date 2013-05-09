using System.Web.Mvc;
using Ninject;

namespace Search.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }


        //TODO: ADD ACTIONS

        public ViewResult Index()
        {
            return View();

        }
    }
}
