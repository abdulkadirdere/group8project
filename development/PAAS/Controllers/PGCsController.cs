using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAAS.DAL;
using PAAS.Models;

namespace PAAS.Controllers
{
    public class PGCsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: PGCs
        public ActionResult Index()
        {
            return View(db.PGCs.ToList());
        }

        // GET: PGCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGC pGC = db.PGCs.Find(id);
            if (pGC == null)
            {
                return HttpNotFound();
            }
            return View(pGC);
        }

        // GET: PGCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PGCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PGC_ID,PGC_First_Name,PGC_Last_Name,PGC_ID_Number,PGC_Email,PGC_Contact_No,PGC_Password,PGC_Status")] PGC pGC)
        {
            if (ModelState.IsValid)
            {
                db.PGCs.Add(pGC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pGC);
        }

        // GET: PGCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGC pGC = db.PGCs.Find(id);
            if (pGC == null)
            {
                return HttpNotFound();
            }
            return View(pGC);
        }

        // POST: PGCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PGC_ID,PGC_First_Name,PGC_Last_Name,PGC_ID_Number,PGC_Email,PGC_Contact_No,PGC_Password,PGC_Status")] PGC pGC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pGC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pGC);
        }

        // GET: PGCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGC pGC = db.PGCs.Find(id);
            if (pGC == null)
            {
                return HttpNotFound();
            }
            return View(pGC);
        }

        // POST: PGCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PGC pGC = db.PGCs.Find(id);
            db.PGCs.Remove(pGC);
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
