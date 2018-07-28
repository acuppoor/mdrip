using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Csv;
using MDRIP.helper;

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

        public ActionResult Choropleth()
        {
            return View();
        }
    }
}
