﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MDRIP.Controllers
{
    public class VisualisationController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Map()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
    }
}