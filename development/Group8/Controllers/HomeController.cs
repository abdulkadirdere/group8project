using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "University of Witwatersrand";

            return View();
        }

        public ActionResult StaffLogin()
        {
            ViewBag.Message = "Please provide valid login details";

            return View();
        }

        public ActionResult ApplicantLogin()
        {
            ViewBag.Message = "Please provide valid login details";

            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Message = "Please click the appropriate option";

            return View();
        }
    }
}