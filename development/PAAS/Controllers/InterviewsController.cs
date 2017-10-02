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
    public class InterviewsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: Interviews
        public ActionResult Index()
        {
            var interviews = db.Interviews.Include(i => i.Application).Include(i => i.Evaluator);
            return View(interviews.ToList());
        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult ApplicationsInterviews()
        {
            var application = db.Applications;
            List<Application> ApplicationList = new List<Application>();
            foreach (Application X in application)
            {
                if (X.Application_Status.Equals("Verified") || X.Application_Status.Equals("InterviewCancelled"))
                    ApplicationList.Add(X);
            }
            return View(ApplicationList);
        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult InterviewList()
        {
            var interview = db.Interviews;
            List<Interview> InterviewList = new List<Interview>();
            foreach (Interview X in interview)
            {
                if (X.Interview_Status.Equals("InterviewPending"))
                    InterviewList.Add(X);
            }

            if (InterviewList.Count == 0)
                return View("~/Views/Home/Index.cshtml");

            else
            {
                return View(InterviewList);
            }


            
        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult Complete(int? id)
        {
            Interview x = db.Interviews.Find(id);
            x.Interview_Status = "InterviewCompleted";

            int i = x.Application_ID;

            Application a = db.Applications.Find(i);
            a.Application_Status = "InterviewCompleted";

            db.Entry(a).State = EntityState.Modified;
            db.Entry(x).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult Cancel(int? id)
        {
            Interview x = db.Interviews.Find(id);
            x.Interview_Status = "InterviewCancelled";

            int i = x.Application_ID;

            Application a = db.Applications.Find(i);
            a.Application_Status = "InterviewCancelled";

            db.Entry(a).State = EntityState.Modified;
            db.Entry(x).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Interviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        // GET: Interviews/Create
        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult Create(int? id)
        {
            List<Application> a = new List<Application>();
            a.Add(db.Applications.Find(id));
            ViewBag.Application_ID = new SelectList(a, "Application_ID", "Application_ID"); ;
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name");
            return View();
        }

        // POST: Interviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Interview_ID,Evaluator_ID,Application_ID,Interview_Date,Interview_Time,Interview_Venue")] Interview interview)
        {

            if (ModelState.IsValid)
            {
                interview.Interview_Status = "InterviewPending";
                int i = interview.Application_ID;
                Application a = db.Applications.Find(i);
                a.Application_Status = "InterviewPending";

                db.Entry(a).State = EntityState.Modified;
                db.Interviews.Add(interview);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No", interview.Application_ID);
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name", interview.Evaluator_ID);
            return View(interview);
        }


        // GET: Interviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No", interview.Application_ID);
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name", interview.Evaluator_ID);
            return View(interview);
        }

        // POST: Interviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Interview_ID,Evaluator_ID,Application_ID,Interview_Date,Interview_Time,Interview_Venue,Interview_Status")] Interview interview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No", interview.Application_ID);
            ViewBag.Evaluator_ID = new SelectList(db.Evaluators, "Evaluator_ID", "Evaluator_First_Name", interview.Evaluator_ID);
            return View(interview);
        }

        // GET: Interviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview interview = db.Interviews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        // POST: Interviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interview interview = db.Interviews.Find(id);
            db.Interviews.Remove(interview);
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
