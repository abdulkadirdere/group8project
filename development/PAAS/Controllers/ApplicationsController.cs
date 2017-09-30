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
    public class ApplicationsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

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

        [HttpPost]
         public ActionResult VerifyApplicationList(int? id)
        {
            Application y = db.Applications.Find(id);
            y.Application_Status = "Verified";
            db.Entry(y).State = EntityState.Modified;
            db.SaveChanges();


            var application = db.Applications;
            List<Application> ApplicationList = new List<Application>();
            foreach (Application X in application)
            {
                if (X.Application_Status.Equals("Received"))
                    ApplicationList.Add(X);
            }
            return View(ApplicationList);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Verify(Application application)
        {
            if (ModelState.IsValid)
            {
                application.Application_Status = "Verified";
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
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
        public ActionResult Create([Bind(Include = "Application_ID,Student_No,Application_Status,Application_Recommend_Desc,Application_Decision_Desc,Applicant_First_Name,Applicant_Last_Name,Applicant_ID_Number,Applicant_Email,Applicant_Contact_No,Applicant_School,Applicant_Faculty,Applicant_Street_No,Applicant_Street_Name,Applicant_Suburb,Applicant_City,Applicant_Province")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.Application_Status = "Received";
                application.Application_Decision_Desc = "";
                application.Application_Recommend_Desc = "";
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
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
