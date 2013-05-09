using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
using System.Web.Routing;
using Search.Helpers.AutoMapper;
using UkAdcHtmlAttributeProvider.Infrastructure;
using Search.Data.Models;
using Search.Data.Services;
using Ninject;

namespace Search
{
    public class Global : System.Web.HttpApplication
    {



           protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.Configure();


            ModelBinders.Binders.DefaultBinder = new Search.Binders.DebuggingModelBinder ();
            //HtmlAttributeProvider.Register(metadata => metadata.IsRequired, "aria-required", true);
            //HtmlAttributeProvider.Register(metadata => metadata.DataTypeName == "Date", "class", "date");

        }
 }

}