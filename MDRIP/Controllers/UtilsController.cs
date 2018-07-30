using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDRIP.helper;

namespace MDRIP.Controllers
{
    public class UtilsController : Controller
    {
        public ActionResult Index()
        {
            return View ("Upload");
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string filename = "";
                string extension = "";
                try
                {
                    filename = Path.GetFileName(file.FileName);
                    int lastDotIndex = filename.LastIndexOf('.');
                    extension = filename.Substring(lastDotIndex + 1, filename.Length - lastDotIndex - 1);
                    extension = extension.ToLower();

                    if (extension.Equals("xls") || extension.Equals("xlsx") || extension.Equals("csv"))
                    {

                        string path = Path.Combine(Server.MapPath("~/Assets"), filename);
                        file.SaveAs(path);
                        readfile(file.InputStream, extension, path);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        ViewBag.Message += "." + extension + " file uploaded successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Unknown file format: " + " " + filename;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message += "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message += "You have not specified a file.";
            }
            return View();
        }

        private void readfile(Stream inputStream, string extension, string path)
        {
            ViewBag.Message += WritingFileToDb.Write(inputStream, extension, path);
        }
    }
}
