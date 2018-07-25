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
    public class BacteriaController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: Bacteria
        public ActionResult Index()
        {
            return View(db.Bacteria.ToList());
        }

        // GET: Bacteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bacteria bacteria = db.Bacteria.Find(id);
            if (bacteria == null)
            {
                return HttpNotFound();
            }
            return View(bacteria);
        }

        // GET: Bacteria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bacteria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Specie,Taxonomy,Definition,GramStaining,Shape,OxygenRequirement,ClinicalCharacteristics,Prevalance,Occurence,Mortality,InvolinDiseases,CausingInfections,Likeness,Treatment,Antibiotics,MDR,InteractionWithOrganism")] Bacteria bacteria)
        {
            if (ModelState.IsValid)
            {
                db.Bacteria.Add(bacteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bacteria);
        }

        // GET: Bacteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bacteria bacteria = db.Bacteria.Find(id);
            if (bacteria == null)
            {
                return HttpNotFound();
            }
            return View(bacteria);
        }

        // POST: Bacteria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Specie,Taxonomy,Definition,GramStaining,Shape,OxygenRequirement,ClinicalCharacteristics,Prevalance,Occurence,Mortality,InvolinDiseases,CausingInfections,Likeness,Treatment,Antibiotics,MDR,InteractionWithOrganism")] Bacteria bacteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bacteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bacteria);
        }

        // GET: Bacteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bacteria bacteria = db.Bacteria.Find(id);
            if (bacteria == null)
            {
                return HttpNotFound();
            }
            return View(bacteria);
        }

        // POST: Bacteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bacteria bacteria = db.Bacteria.Find(id);
            db.Bacteria.Remove(bacteria);
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
