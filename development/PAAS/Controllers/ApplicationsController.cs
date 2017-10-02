using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAAS.DAL;
using PAAS.Models;
using System.IO;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace PAAS.Controllers
{
    public class ApplicationsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }
        [Authorize(Users = "PGO")]
        public ActionResult VerifyApplicationList()
        {
            var application = db.Applications;
            List<Application> ApplicationList = new List<Application>();
            foreach (Application X in application)
            {
                if (X.Application_Status.Equals("Received"))
                ApplicationList.Add(X);
            }
            return View(ApplicationList);
        }

        [Authorize(Users = "PGC")]
        public ActionResult AcceptApplicationList()
        {
            var application = db.Applications;
            List<Application> ApplicationList = new List<Application>();
            foreach (Application X in application)
            {
                if (X.Application_Status.Equals("Recommended") || X.Application_Status.Equals("NotRecommended"))
                    ApplicationList.Add(X);
            }
            return View(ApplicationList);
        }

        [Authorize(Users = "PGC")]
        public ActionResult Accept(int? id)
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

        [Authorize(Users = "PGC")]
        public ActionResult Accept2(int? id)
        {

            Application application = db.Applications.Find(id);
            application.Application_Status = "Accepted";
            db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AcceptDesciption/" + id, "Applications");

        }

        [Authorize(Users = "PGC")]
        public ActionResult Reject(int? id)
        {

            Application application = db.Applications.Find(id);
            application.Application_Status = "Rejected";
            db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AcceptDesciption/" + id, "Applications");

        }

        [Authorize(Users = "PGC")]
        public ActionResult AcceptDesciption(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptDesciption([Bind(Include = "Application_ID,Student_No,Application_Status,Application_Recommend_Desc,Application_Decision_Desc,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", "Home");
            }
            return View(application);
        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult RecommendApplicationList()
        {
            var application = db.Applications;
            List<Application> ApplicationList = new List<Application>();
            foreach (Application X in application)
            {
                if (X.Application_Status.Equals("Verified") || X.Application_Status.Equals("InterviewCompleted"))
                    ApplicationList.Add(X);
            }
            return View(ApplicationList);
        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult Recommend(int? id)
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

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult Recommend2(int? id)
        {

            Application application = db.Applications.Find(id);
            application.Application_Status = "Recommended";
            db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RecommendDesciption/" + id, "Applications");

        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult NotRecommended(int? id)
        {

            Application application = db.Applications.Find(id);
            application.Application_Status = "NotRecommended";
            db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RecommendDesciption/" + id, "Applications");

        }

        [Authorize(Users = "PGC, Evaluator")]
        public ActionResult RecommendDesciption(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecommendDesciption([Bind(Include = "Application_ID,Student_No,Application_Status,Application_Recommend_Desc,Application_Decision_Desc,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", "Home");
            }
            return View(application);
        }

        [Authorize(Users = "PGO")]
        public ActionResult Verify(int? id)
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

        [Authorize(Users = "PGO")]
        public ActionResult Verify2(int? id)
        {
            
                Application application = db.Applications.Find(id);
                application.Application_Status = "Verified";
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

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
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_ID,Student_No,Application_Status,Application_Recommend_Desc,Application_Decision_Desc,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application, HttpPostedFileBase files)
        {
            if (ModelState.IsValid)
            {
                application.Application_Status = "Received";
                application.Application_Decision_Desc = "";
                application.Application_Recommend_Desc = "";
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Upload", "Documents");
            }

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
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_ID,Student_No,Application_Status,Application_Recommend_Desc,Application_Decision_Desc,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
