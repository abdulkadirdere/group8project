using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group8.DAL;
using Group8.Models;

namespace Group8.Controllers
{
    public class PGFOsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: PGFOs
        public ActionResult Index()
        {
            return View(db.PGFOs.ToList());
        }

        // GET: PGFOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGFO pGFO = db.PGFOs.Find(id);
            if (pGFO == null)
            {
                return HttpNotFound();
            }
            return View(pGFO);
        }

        // GET: PGFOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PGFOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PGFO_ID,PGFO_First_Name,PGFO_Last_Name,PGFO_ID_Number,PGFO_Email,PGFO_Contact_No,PGFO_Status")] PGFO pGFO)
        {
            if (ModelState.IsValid)
            {
                db.PGFOs.Add(pGFO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pGFO);
        }

        // GET: PGFOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGFO pGFO = db.PGFOs.Find(id);
            if (pGFO == null)
            {
                return HttpNotFound();
            }
            return View(pGFO);
        }

        // POST: PGFOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PGFO_ID,PGFO_First_Name,PGFO_Last_Name,PGFO_ID_Number,PGFO_Email,PGFO_Contact_No,PGFO_Status")] PGFO pGFO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pGFO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pGFO);
        }

        // GET: PGFOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGFO pGFO = db.PGFOs.Find(id);
            if (pGFO == null)
            {
                return HttpNotFound();
            }
            return View(pGFO);
        }

        // POST: PGFOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PGFO pGFO = db.PGFOs.Find(id);
            db.PGFOs.Remove(pGFO);
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
