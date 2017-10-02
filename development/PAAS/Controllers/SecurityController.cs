using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PAAS.DAL;
using PAAS.Models;
using System.Net.Mail;

namespace WebApplication3.Controllers
{
    public class SecurityController : Controller
    {
        private PAASContext db = new PAASContext();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [AllowAnonymous]
        public ActionResult LoginError()
        {
            return View("LoginError");
        }

        public ActionResult PGOCheckUser()
        {
            string strEmail = Request.Form["txtuseremail"];
            string strPass = Request.Form["txtpassword"];

            int id = -1;
            string sname = "";
            foreach (PGO x in db.PGOs.ToList())
            {
                if (x.PGO_Email.Equals(strEmail) && x.PGO_Password.Equals(strPass))
                {
                    id = x.PGO_ID;
                    sname = "PGO";
                    FormsAuthentication.SetAuthCookie(sname, false);
                }
            }

            return RedirectToAction("Details/" + id, "PGOs");
        }

        public ActionResult CheckUser()
        {
            string strEmail = Request.Form["txtuseremail"];
            string strPass = Request.Form["txtpassword"];

            int id = -1;
            string sname = "";
            foreach (Evaluator x in db.Evaluators.ToList())
            {
                if (x.Evaluator_Email.Equals(strEmail) && x.Evaluator_Password.Equals(strPass))
                {
                    id = x.Evaluator_ID;
                    sname = "Evaluator";
                    FormsAuthentication.SetAuthCookie(sname, false);
                    return RedirectToAction("Details/" + id, "Evaluators");
                }
            }

            if (id == -1)
            {
                foreach (PGO x in db.PGOs.ToList())
                {
                    if (x.PGO_Email.Equals(strEmail) && x.PGO_Password.Equals(strPass))
                    {
                        id = x.PGO_ID;
                        sname = "PGO";
                        FormsAuthentication.SetAuthCookie(sname, false);
                        return RedirectToAction("Details/" + id, "PGOs");
                    }
                }

                

            }

            if (id == -1)
            {
                foreach (PGFO x in db.PGFOs.ToList())
                {
                    if (x.PGFO_Email.Equals(strEmail) && x.PGFO_Password.Equals(strPass))
                    {
                        id = x.PGFO_ID;
                        sname = "PGFO";
                        FormsAuthentication.SetAuthCookie(sname, false);
                        return RedirectToAction("Details/" + id, "PGFOs");
                    }
                }

                

            }

            if (id == -1)
            {
                foreach (PGC x in db.PGCs.ToList())
                {
                    if (x.PGC_Email.Equals(strEmail) && x.PGC_Password.Equals(strPass))
                    {
                        id = x.PGC_ID;
                        sname = "PGC";
                        FormsAuthentication.SetAuthCookie(sname, false);
                        return RedirectToAction("Details/" + id, "PGCs");
                    }
                }

            }

                return RedirectToAction("LoginError");
        }
    }
}