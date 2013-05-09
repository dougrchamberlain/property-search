using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Reflection;

public static class Helpers
{
    public static MvcHtmlString RangeFor<T>(this HtmlHelper helper, T item1, T item2)
    {
        TagBuilder from;
        TagBuilder to;

        StringBuilder rangeEditor = new StringBuilder();

        from = new TagBuilder("input");
        to = new TagBuilder("input");
        from.Attributes["name"] = item1.GetType().GetProperties()[0].Name + "From";
        to.Attributes["name"] = item2.GetType().GetProperties()[0].Name + "To";

        from.Attributes["id"] = from.Attributes["name"];
        to.Attributes["id"] = from.Attributes["name"];

        rangeEditor.Append(from.ToString());
        rangeEditor.Append(to.ToString());

        return MvcHtmlString.Create(rangeEditor.ToString()); 

    }


    public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

}