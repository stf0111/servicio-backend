﻿using System.Web;
using System.Web.Mvc;

namespace Rest_Suple
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
