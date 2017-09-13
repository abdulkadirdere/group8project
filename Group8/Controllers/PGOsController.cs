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
    public class PGOsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: PGOs
        public ActionResult Index()
        {
            return View(db.PGOs.ToList());
        }

        // GET: PGOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGO pGO = db.PGOs.Find(id);
            if (pGO == null)
            {
                return HttpNotFound();
            }
            return View(pGO);
        }

        // GET: PGOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PGOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PGO_ID,PGO_First_Name,PGO_Last_Name,PGO_ID_Number,PGO_Email,PGO_Contact_No,PGO_Password,PGO_Status")] PGO pGO)
        {
            if (ModelState.IsValid)
            {
                db.PGOs.Add(pGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pGO);
        }

        // GET: PGOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGO pGO = db.PGOs.Find(id);
            if (pGO == null)
            {
                return HttpNotFound();
            }
            return View(pGO);
        }

        // POST: PGOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PGO_ID,PGO_First_Name,PGO_Last_Name,PGO_ID_Number,PGO_Email,PGO_Contact_No,PGO_Password,PGO_Status")] PGO pGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pGO);
        }

        // GET: PGOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PGO pGO = db.PGOs.Find(id);
            if (pGO == null)
            {
                return HttpNotFound();
            }
            return View(pGO);
        }

        // POST: PGOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PGO pGO = db.PGOs.Find(id);
            db.PGOs.Remove(pGO);
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
