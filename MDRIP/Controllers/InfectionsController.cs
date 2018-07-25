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
    public class InfectionsController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: Infections
        public ActionResult Index()
        {
            return View(db.Infections.ToList());
        }

        // GET: Infections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infections infections = db.Infections.Find(id);
            if (infections == null)
            {
                return HttpNotFound();
            }
            return View(infections);
        }

        // GET: Infections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Infections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Name,Definition,Classification,Symptoms,Seasonal,Pathophysiology,MyProperty,CausingBacteria,ModeOfTransmission,Diagnosis,Prevention,Treatment,Epidimology,DeathRate,History,ReportingInstitute,ReportAuthor")] Infections infections)
        {
            if (ModelState.IsValid)
            {
                db.Infections.Add(infections);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infections);
        }

        // GET: Infections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infections infections = db.Infections.Find(id);
            if (infections == null)
            {
                return HttpNotFound();
            }
            return View(infections);
        }

        // POST: Infections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Name,Definition,Classification,Symptoms,Seasonal,Pathophysiology,MyProperty,CausingBacteria,ModeOfTransmission,Diagnosis,Prevention,Treatment,Epidimology,DeathRate,History,ReportingInstitute,ReportAuthor")] Infections infections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infections);
        }

        // GET: Infections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infections infections = db.Infections.Find(id);
            if (infections == null)
            {
                return HttpNotFound();
            }
            return View(infections);
        }

        // POST: Infections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Infections infections = db.Infections.Find(id);
            db.Infections.Remove(infections);
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
