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
using System.IO;

namespace PAAS.Controllers
{
    public class DocumentsController : Controller
    {
        private PAASContext db = new PAASContext();

        // GET: Documents
        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.Application);
            return View(documents.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No");
            return View();
        }

        public ActionResult Upload()
        {
            return View();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase files)
        {

            String FileExt = Path.GetExtension(files.FileName).ToUpper();

            if (FileExt == ".PDF")
            {
                Stream str = files.InputStream;
                BinaryReader Br = new BinaryReader(str);
                Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                Document document = new Document();

                List<Application> l = db.Applications.ToList();
                List<int> k = new List<int>();

                foreach(Application a in l)
                {
                    k.Add(a.Application_ID);
                }

                int max = k.Max();

                //document.Document_ID = 1;
                document.Application_ID = max;
                document.Document_File = FileDet;
                document.Document_Name = files.FileName;
                document.Document_Type = "Application";
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {

                ViewBag.FileStatus = "Invalid file format.";
                return View();

            }


        }


        [HttpGet]
        public FileResult Download(int id)
        {


            List<Document> ObjFiles = db.Documents.ToList();

            var FileById = (from FC in ObjFiles
                            where FC.Application_ID.Equals(id)
                            select new { FC.Document_Name, FC.Document_File }).ToList().FirstOrDefault();

            return File(FileById.Document_File, "application/pdf", FileById.Document_Name);

        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Document_ID,Application_ID,Document_Name,Document_Type,Document_File")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No", document.Application_ID);
            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No", document.Application_ID);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Document_ID,Application_ID,Document_Name,Document_Type,Document_File")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Application_ID = new SelectList(db.Applications, "Application_ID", "Student_No", document.Application_ID);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
