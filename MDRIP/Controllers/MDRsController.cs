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
    public class MDRsController : Controller
    {
        private MDRIPContext db = new MDRIPContext();

        // GET: MDRs
        public ActionResult Index()
        {
            return View(db.MDRs.ToList());
        }

        // GET: MDRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MDR mDR = db.MDRs.Find(id);
            if (mDR == null)
            {
                return HttpNotFound();
            }
            return View(mDR);
        }

        // GET: MDRs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MDRs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AccessionID,BacteriaName,Antibiotics,DeathRate,Enviromental,Adaptability,Genetics,District,History")] MDR mDR)
        {
            if (ModelState.IsValid)
            {
                db.MDRs.Add(mDR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mDR);
        }

        // GET: MDRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MDR mDR = db.MDRs.Find(id);
            if (mDR == null)
            {
                return HttpNotFound();
            }
            return View(mDR);
        }

        // POST: MDRs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AccessionID,BacteriaName,Antibiotics,DeathRate,Enviromental,Adaptability,Genetics,District,History")] MDR mDR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mDR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mDR);
        }

        // GET: MDRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MDR mDR = db.MDRs.Find(id);
            if (mDR == null)
            {
                return HttpNotFound();
            }
            return View(mDR);
        }

        // POST: MDRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MDR mDR = db.MDRs.Find(id);
            db.MDRs.Remove(mDR);
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
