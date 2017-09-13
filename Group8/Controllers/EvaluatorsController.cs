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
    public class EvaluatorsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: Evaluators
        public ActionResult Index()
        {
            return View(db.Evaluators.ToList());
        }

        // GET: Evaluators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluator evaluator = db.Evaluators.Find(id);
            if (evaluator == null)
            {
                return HttpNotFound();
            }
            return View(evaluator);
        }

        // GET: Evaluators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Evaluator_ID,Evaluator_First_Name,Evaluator_Last_Name,Evaluator_ID_Number,Evaluator_Email,Evaluator_Contact_No,Evaluator_Type,Evaluator_Password,Evaluator_Status")] Evaluator evaluator)
        {
            if (ModelState.IsValid)
            {
                db.Evaluators.Add(evaluator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluator);
        }

        // GET: Evaluators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluator evaluator = db.Evaluators.Find(id);
            if (evaluator == null)
            {
                return HttpNotFound();
            }
            return View(evaluator);
        }

        // POST: Evaluators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Evaluator_ID,Evaluator_First_Name,Evaluator_Last_Name,Evaluator_ID_Number,Evaluator_Email,Evaluator_Contact_No,Evaluator_Type,Evaluator_Password,Evaluator_Status")] Evaluator evaluator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluator);
        }

        // GET: Evaluators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluator evaluator = db.Evaluators.Find(id);
            if (evaluator == null)
            {
                return HttpNotFound();
            }
            return View(evaluator);
        }

        // POST: Evaluators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluator evaluator = db.Evaluators.Find(id);
            db.Evaluators.Remove(evaluator);
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
