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
    public class DiagnosticCentersController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: DiagnosticCenters
        public ActionResult Index()
        {
            return View(db.DiagnosticCenters.ToList());
        }

        // GET: DiagnosticCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiagnosticCenter diagnosticCenter = db.DiagnosticCenters.Find(id);
            if (diagnosticCenter == null)
            {
                return HttpNotFound();
            }
            return View(diagnosticCenter);
        }

        // GET: DiagnosticCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiagnosticCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type,District,Address,EmailID,Contact,ReproInfection,MDRPathogen,PatientInfection,AntibioticResistence")] DiagnosticCenter diagnosticCenter)
        {
            if (ModelState.IsValid)
            {
                db.DiagnosticCenters.Add(diagnosticCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diagnosticCenter);
        }

        // GET: DiagnosticCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiagnosticCenter diagnosticCenter = db.DiagnosticCenters.Find(id);
            if (diagnosticCenter == null)
            {
                return HttpNotFound();
            }
            return View(diagnosticCenter);
        }

        // POST: DiagnosticCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,District,Address,EmailID,Contact,ReproInfection,MDRPathogen,PatientInfection,AntibioticResistence")] DiagnosticCenter diagnosticCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnosticCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnosticCenter);
        }

        // GET: DiagnosticCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiagnosticCenter diagnosticCenter = db.DiagnosticCenters.Find(id);
            if (diagnosticCenter == null)
            {
                return HttpNotFound();
            }
            return View(diagnosticCenter);
        }

        // POST: DiagnosticCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiagnosticCenter diagnosticCenter = db.DiagnosticCenters.Find(id);
            db.DiagnosticCenters.Remove(diagnosticCenter);
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
