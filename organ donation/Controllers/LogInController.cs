using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccessLayer;
using organ_donation.Models;

namespace organ_donation.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(SignInModel S)
        {
          //throw new Exception("MyErrorMessage");
            if(ModelState.IsValid)
            {
                //TO DB
                DAL obj = new DAL();
                LoginDetails det = obj.VerifyLogin(S.Username, S.Password);
                if (det != null)
                {
                    //After LogIn.......
                    Session["UInfo"] = det;
                    Session["uid"] = det.UserID;
                    if (det.RoleID == 1)
                    {
                        return RedirectToAction("BaseManagerView", "Main");
                    }
                    else if(det.RoleID==2)
                    {
                        return RedirectToAction("BaseDoctorView", "Main");
                    }
                    else if(det.RoleID==3)
                    {
                        return RedirectToAction("BaseNomineeView", "Main");
                    }
                    else if(det.RoleID==4)
                    {
                        return RedirectToAction("BaseAccepterView", "Main");
                    }

                }
                else
                {
                    ViewBag.msg = "Incorrect Credentials";
                }
            }
            return View(S);
        }
        public ActionResult RegisterNominee( )
        {
           RegisterNomineeModel m = new RegisterNomineeModel();
            return View(m);
        }
        [HttpPost]
        public ActionResult RegisterNominee(RegisterNomineeModel inp)
        {
            //RegisterNomineeModel model = new RegisterNomineeModel();
            if (ModelState.IsValid)
            {
                DAL obj = new DAL();
                RegisterNominee nm = new RegisterNominee();
                nm.BloodGroup = inp.BloodGroup;
                nm.NomineeName = inp.NomineeName;
                nm.Username = inp.Username;
                nm.CPwd = inp.CPwd;
                nm.DonorName = inp.DonorName;
                nm.DonorAge = inp.DonorAge;
                nm.DonorGender = inp.DonorGender;
                nm.Date = inp.Date;
                nm.Location = inp.Location;
                nm.Contact = inp.Contact;
               bool res= obj.EnterNomineeData(nm);
                if (res == true)
                {
                    ViewBag.msg = "Nominee Registered Sucessfully......";
                }
                else
                {
                    ViewBag.msg = "Nominee Registration Failed........";

                }
            }
            return View(inp);
           
        }
        public ActionResult RegisterAccepter()
        {
            RegisterAccepterModel R = new RegisterAccepterModel();
            return View(R);
        }
        [HttpPost]
        public ActionResult RegisterAccepter(RegisterAccepterModel inp)
        {

            if(ModelState.IsValid)
            {
                DAL obj = new DAL();
                RegisterAccepter RA = new RegisterAccepter();
                RA.AccepterName = inp.NAME;
                RA.Username = inp.Username;
                RA.CPwd = inp.CPwd;
                RA.RequirementOrgon = inp.REQUIREMENT;
                RA.AccepterAge = inp.AGE;
                RA.DonorGender = inp.GENDER;
                RA.Location = inp.LOCATION;
                RA.BloodGroup = inp.BLOOD_GROUP;
                RA.Contact = inp.CONTACT_NUMBER;

             bool res= obj.EnterAccepterData(RA);
                if(res==true)
                {
                    ViewBag.msg = "Accepter Registered Sucessfully.....";
                }
                else
                {
                    ViewBag.msg = "Accepter Registration Failed.........";
                }

            }
            return View(inp);
        }
    }
}