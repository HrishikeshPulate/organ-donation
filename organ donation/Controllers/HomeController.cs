using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccessLayer;

namespace organ_donation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DAL obj = new DAL();
            LoginDetails det= obj.VerifyLogin("test", "test");
            if (det != null)
            {
                //Successful login....
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}