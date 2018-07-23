using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MDRIP.Models;

namespace MDRIP.Controllers
{
    public class BacterialEcologiesController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: BacterialEcologies
        public ActionResult Index()
        {
            return View(db.BacterialEcologies.ToList());
        }

        // GET: BacterialEcologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacterialEcology bacterialEcology = db.BacterialEcologies.Find(id);
            if (bacterialEcology == null)
            {
                return HttpNotFound();
            }
            return View(bacterialEcology);
        }

        // GET: BacterialEcologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BacterialEcologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,District,Habitat,Infections,Diseases,DeathRate,ModeOfTransmission,Prevention,Treatment")] BacterialEcology bacterialEcology)
        {
            if (ModelState.IsValid)
            {
                db.BacterialEcologies.Add(bacterialEcology);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bacterialEcology);
        }

        // GET: BacterialEcologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacterialEcology bacterialEcology = db.BacterialEcologies.Find(id);
            if (bacterialEcology == null)
            {
                return HttpNotFound();
            }
            return View(bacterialEcology);
        }

        // POST: BacterialEcologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,District,Habitat,Infections,Diseases,DeathRate,ModeOfTransmission,Prevention,Treatment")] BacterialEcology bacterialEcology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bacterialEcology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bacterialEcology);
        }

        // GET: BacterialEcologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacterialEcology bacterialEcology = db.BacterialEcologies.Find(id);
            if (bacterialEcology == null)
            {
                return HttpNotFound();
            }
            return View(bacterialEcology);
        }

        // POST: BacterialEcologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BacterialEcology bacterialEcology = db.BacterialEcologies.Find(id);
            db.BacterialEcologies.Remove(bacterialEcology);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
