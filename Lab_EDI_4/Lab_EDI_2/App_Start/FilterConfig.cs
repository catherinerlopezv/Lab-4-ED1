﻿using System.Web;
using System.Web.Mvc;

namespace Lab_EDI_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
