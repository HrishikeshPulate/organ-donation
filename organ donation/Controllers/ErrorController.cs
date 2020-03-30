using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace organ_donation.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult CustomErrorPage()
        {
            return View();
        }
    }
}