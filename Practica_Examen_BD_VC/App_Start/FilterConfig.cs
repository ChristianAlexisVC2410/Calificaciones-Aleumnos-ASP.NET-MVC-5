﻿using System.Web;
using System.Web.Mvc;

namespace Practica_Examen_BD_VC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
