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
    public class ClinicalInformationsController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: ClinicalInformations
        public ActionResult Index()
        {
            return View(db.ClinicalInformations.ToList());
        }

        // GET: ClinicalInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClinicalInformation clinicalInformation = db.ClinicalInformations.Find(id);
            if (clinicalInformation == null)
            {
                return HttpNotFound();
            }
            return View(clinicalInformation);
        }

        // GET: ClinicalInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicalInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClinicName,ClinicAddress,ClincFormNumber,ClinicRecords,ClincRecordsProviderID,ClinicalInfectionsInformation")] ClinicalInformation clinicalInformation)
        {
            if (ModelState.IsValid)
            {
                db.ClinicalInformations.Add(clinicalInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinicalInformation);
        }

        // GET: ClinicalInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClinicalInformation clinicalInformation = db.ClinicalInformations.Find(id);
            if (clinicalInformation == null)
            {
                return HttpNotFound();
            }
            return View(clinicalInformation);
        }

        // POST: ClinicalInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClinicName,ClinicAddress,ClincFormNumber,ClinicRecords,ClincRecordsProviderID,ClinicalInfectionsInformation")] ClinicalInformation clinicalInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinicalInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinicalInformation);
        }

        // GET: ClinicalInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClinicalInformation clinicalInformation = db.ClinicalInformations.Find(id);
            if (clinicalInformation == null)
            {
                return HttpNotFound();
            }
            return View(clinicalInformation);
        }

        // POST: ClinicalInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClinicalInformation clinicalInformation = db.ClinicalInformations.Find(id);
            db.ClinicalInformations.Remove(clinicalInformation);
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
