using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Search.Helpers
{
    public static partial class Extensions
    {

        public static string AsQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where (p.GetValue(obj, null) != null && p.IsPropertyScaffolded() )
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
            var result = String.Join("&", properties.ToArray());
            return result;
        }

        public static bool IsPropertyScaffolded(this PropertyInfo propertyinfo)
        {
            var scaffoldedcolumns = (from p in propertyinfo.GetCustomAttributes(true).AsEnumerable<Object>()
                                     where p.GetType() == typeof(ScaffoldColumnAttribute)
                                     select (ScaffoldColumnAttribute)p);


            return scaffoldedcolumns.All(z => z.Scaffold == true);

        }
    }
}
