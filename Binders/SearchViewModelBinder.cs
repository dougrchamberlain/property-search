using System.Web.Mvc;
using Search.Components.Html.ViewModels;
using System.Web;
using System.Reflection;
using Search.Helpers;
using System.Collections.Specialized;
using System;  

namespace Search.Binders
{
    public class DebuggingModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext, Type modelType)
        {
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

    }
}