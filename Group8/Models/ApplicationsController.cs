using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group8.DAL;

namespace Group8.Models
{
    public class ApplicationsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: Applications
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.Evaluator).Include(a => a.PGC).Include(a => a.PGFO).Include(a => a.PGO);
            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name");
            ViewBag.PGC_ID = new SelectList(db.PGCs, "PGC_ID", "PGC_First_Name");
            ViewBag.PGFO_ID = new SelectList(db.PGFOs, "PGFO_ID", "PGFO_First_Name");
            ViewBag.PGO_ID = new SelectList(db.PGOs, "PGO_ID", "PGO_First_Name");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_ID,PGO_ID,PGFO_ID,PGC_ID,Evaluator_ID,Student_No,Application_Status,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name", application.Evaluator_ID);
            ViewBag.PGC_ID = new SelectList(db.PGCs, "PGC_ID", "PGC_First_Name", application.PGC_ID);
            ViewBag.PGFO_ID = new SelectList(db.PGFOs, "PGFO_ID", "PGFO_First_Name", application.PGFO_ID);
            ViewBag.PGO_ID = new SelectList(db.PGOs, "PGO_ID", "PGO_First_Name", application.PGO_ID);
            return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name", application.Evaluator_ID);
            ViewBag.PGC_ID = new SelectList(db.PGCs, "PGC_ID", "PGC_First_Name", application.PGC_ID);
            ViewBag.PGFO_ID = new SelectList(db.PGFOs, "PGFO_ID", "PGFO_First_Name", application.PGFO_ID);
            ViewBag.PGO_ID = new SelectList(db.PGOs, "PGO_ID", "PGO_First_Name", application.PGO_ID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_ID,PGO_ID,PGFO_ID,PGC_ID,Evaluator_ID,Student_No,Application_Status,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name", application.Evaluator_ID);
            ViewBag.PGC_ID = new SelectList(db.PGCs, "PGC_ID", "PGC_First_Name", application.PGC_ID);
            ViewBag.PGFO_ID = new SelectList(db.PGFOs, "PGFO_ID", "PGFO_First_Name", application.PGFO_ID);
            ViewBag.PGO_ID = new SelectList(db.PGOs, "PGO_ID", "PGO_First_Name", application.PGO_ID);
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
