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
    public class EmergencyPreparationsController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: EmergencyPreparations
        public ActionResult Index()
        {
            return View(db.EmergencyPreparations.ToList());
        }

        // GET: EmergencyPreparations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyPreparation emergencyPreparation = db.EmergencyPreparations.Find(id);
            if (emergencyPreparation == null)
            {
                return HttpNotFound();
            }
            return View(emergencyPreparation);
        }

        // GET: EmergencyPreparations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyPreparations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CoordinatingHealthRegionalState,Developing_DisseminatingInformationToMedicalCommunnity,PartnersToImplementPHDContainmentMeaseures,CoordinteWithMCS,EpidemiologyInvestigationActivities,CollectingAndAnalysingDataToDevelopObjectives")] EmergencyPreparation emergencyPreparation)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyPreparations.Add(emergencyPreparation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emergencyPreparation);
        }

        // GET: EmergencyPreparations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyPreparation emergencyPreparation = db.EmergencyPreparations.Find(id);
            if (emergencyPreparation == null)
            {
                return HttpNotFound();
            }
            return View(emergencyPreparation);
        }

        // POST: EmergencyPreparations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CoordinatingHealthRegionalState,Developing_DisseminatingInformationToMedicalCommunnity,PartnersToImplementPHDContainmentMeaseures,CoordinteWithMCS,EpidemiologyInvestigationActivities,CollectingAndAnalysingDataToDevelopObjectives")] EmergencyPreparation emergencyPreparation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyPreparation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emergencyPreparation);
        }

        // GET: EmergencyPreparations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyPreparation emergencyPreparation = db.EmergencyPreparations.Find(id);
            if (emergencyPreparation == null)
            {
                return HttpNotFound();
            }
            return View(emergencyPreparation);
        }

        // POST: EmergencyPreparations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyPreparation emergencyPreparation = db.EmergencyPreparations.Find(id);
            db.EmergencyPreparations.Remove(emergencyPreparation);
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
