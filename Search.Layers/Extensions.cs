using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Search.Data.Models;
using Search.Data;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using LinqKit;

namespace Search.Data
{
    public static class Extensions
    {

  
        [Obsolete]
        public static int GrossArea(this Parcel parcel)
        {
            return (from b in parcel.Buildings
                    select b.GROSS_AREA).Sum() ?? 0;

        }

        [Obsolete] 
        public static int LivingArea(this Parcel parcel)
        {
            return (from b in parcel.Buildings
                    select b.LIVING_AREA).Sum() ?? 0;
        }

        //TODO: FIX NULL EXCEPTION HERE
        [Obsolete]  
        public static string DelineatedDistrict(this Parcel parcel)
        {
            String result = null;
            if (parcel.Characteristics != null)
            {
                result = (from c in parcel.Characteristics
                          where c.CAT_CD == "DD"
                          select c.DSCR).FirstOrDefault();
            }


            return result;
        }


        public static string AsParcelID(this string input)
        {
            input = input.Insert(4, "-").Insert(7, "-");
            return input;
        }

        public static string AsStrap(this String input)
        {
            input = input ?? "";
            input = Regex.Replace(input, @"[^\d]", "");
            return input;
        }



    }



    }
