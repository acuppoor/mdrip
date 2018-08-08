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

        public ActionResult Visualisations(string id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
