using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using organ_donation.Models;

namespace organ_donation.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult BaseManagerView()
        {
            
      
            
            DAL obj = new DAL();
            List<ViewCasePool> CpList = obj.RetriveCaseData();
            List<CasePoolViewModel> VList = new List<CasePoolViewModel>();
            foreach (ViewCasePool item in CpList)
            {
                CasePoolViewModel c = new CasePoolViewModel();
                c.CaseId = item.CaseId;
                c.AccepterId = item.AccepterId;
                c.DoctorId = item.DoctorId;
                c.DonorId = item.DonorId;
                c.Organs = item.Organs;
                c.Status = item.Status;
                VList.Add(c);
            }
            return View(VList);
        }
        public ActionResult AssignDoctor(int cid)
        {
            Session["cid"] = cid;
            DAL obj = new DAL();
            List<ViewDoctor> DoctorList = obj.RetreiveDoctors();
             ViewDoctorModel d = new ViewDoctorModel();
            foreach (ViewDoctor item in DoctorList)
            {
                SelectListItem dentry = new SelectListItem() { Text=item.DoctorName,Value=item.DoctorId.ToString()};
               
                d.DocList.Add(dentry);
                
            }
            return View(d);
        }
        [HttpPost]
        public ActionResult AssignDoctor(AssignDoctorModel AsD)
        {
            
            DAL obj = new DAL();
            AssignDoctor AsDoc = new AssignDoctor();
            AsDoc.cid = (int)Session["cid"];        //type Casting
            AsDoc.DoctorId =AsD.DoctorId;
            bool res = obj.AssignDoctor(AsDoc);
            if (res == true)
            {
                ViewBag.msg = "Assigned Sucessfully.....";
               
            }
            else
            {
                ViewBag.msg = "Assigned Failed.........";
            }
            ViewDoctorModel d = new ViewDoctorModel();
            List<ViewDoctor> DoctorList = obj.RetreiveDoctors();
            foreach (ViewDoctor item in DoctorList)
            {
                SelectListItem dentry = new SelectListItem() { Text = item.DoctorName, Value = item.DoctorId.ToString() };

                d.DocList.Add(dentry);

            }
            return View(d);
        }
        public ActionResult AssignAccepter(int cid)
        {
            Session["cid"] = cid;
            DAL obj = new DAL();
            bool res = obj.AssignAccepter(cid);
            if (res == true)
            {
                Session["alert"] = "Assigned......";
            }
            else
            {
                Session["alert"] = "Failed.....";
            }
            return RedirectToAction("BaseManagerView", "Main");
        }



        /*public ActionResult AssignDonor(int did)
        {
            Session["did"] = did;
            DAL obj = new DAL();
            List<ViewDonor> DonorList = obj.RetreiveDonors();
            ViewDonorModel d = new ViewDonorModel();
            foreach (ViewDonor item in DonorList)
            {
                SelectListItem dentry = new SelectListItem() { Text = item.DonorName, Value = item.DonorId.ToString() };
                d.DonorList.Add(dentry);
            }
            return View(d);
        }*/
        public ActionResult BaseDoctorView()
        {
            int uid = (int)Session["uid"];
         
            DAL obj = new DAL();
            List<ViewCasePool> CpList = obj.DoctorCaseData(uid);
            List<CasePoolViewModel> VList = new List<CasePoolViewModel>();
            foreach (ViewCasePool item in CpList)
            {
                CasePoolViewModel c = new CasePoolViewModel();
                c.CaseId = item.CaseId;
                c.AccepterId = item.AccepterId;
                c.DoctorId = item.DoctorId;
                c.DonorId = item.DonorId;
                c.Organs = item.Organs;
                c.Status = item.Status;
                VList.Add(c);
            }
            return View(VList);
        }
        public ActionResult VerifyDonor(int cid)
        {
            Session["cid"] = cid;
            VerifyDonorModel m = new VerifyDonorModel();
            return View(m);
        }
        [HttpPost]
        public ActionResult VerifyDonor(VerifyDonorModel vdm)
        {
            DAL obj = new DAL();
            VerifyDonor vd = new VerifyDonor(); 
            vd.CaseId=(int)Session["cid"];
            vd.Status = vdm.status;
            vd.Orgon = vdm.Orgon;
            bool res = obj.UpdateVerificationStatus(vd);
            if (res == true)
            {
                ViewBag.msg = "Successfull.....";
            }
            else
            {
                ViewBag.msg = "Failed......";
            
            }
            return View(vdm);
        }
        public ActionResult BaseNomineeView()
        {
            DAL obj = new DAL();
            NomineeView nv = new NomineeView();
            nv.UserId = (int)Session["uid"];
            List<NomineeView> NDet = obj.GetNominee(nv);
            List<NomineeViewModel> NList = new List<NomineeViewModel>();
            foreach (NomineeView item in NDet)
            {
                NomineeViewModel nd = new NomineeViewModel();
                nd.NomineeName = item.NomineeName;
                nd.DonorName = item.DonorName;
                nd.Date = item.Date;
                nd.Contact = item.Contact;
                nd.DonorAge = item.DonorAge;
                nd.DonorGender = item.DonorGender;
                nd.Location = item.Location;
                nd.BloodGroup = item.BloodGroup;
                nd.Status = item.Status;
                nd.UserId = item.UserId;
                NList.Add(nd);
            }
            return View(NList);
        }
        public ActionResult BaseAccepterView()
        {
            DAL obj = new DAL();
            AccepterView av = new AccepterView();
            av.UserId = (int)Session["uid"];
            List<AccepterView> Adet = obj.GetAccepter(av);
            List<AccepterViewModel> Alist = new List<AccepterViewModel>();
            foreach(AccepterView item in Adet)
            {
                AccepterViewModel nd = new AccepterViewModel();
                nd.ACEEPTER_ID = item.AccepterId;
                nd.NAME = item.AccepterName;
                nd.REQUIREMENT = item.Requirement;
                nd.STATUS = item.Status;
                nd.GENDER = item.Gender;
                nd.LOCATION = item.Location;
                nd.DATE = item.Date;
                nd.AGE = item.Age;
                nd.BLOOD_GROUP = item.BloodGroup;
                nd.CONTACT_NUMBER = item.Contact;
                Alist.Add(nd);
            }
            return View(Alist);
        }
        public ActionResult BookAppointment(int aid)
        {
            Session["aid"] = aid;
            BookAppointmentModel b = new BookAppointmentModel();
            return View(b);
        }

        [HttpPost]
        public ActionResult BookAppointment(BookAppointmentModel ba)
        {
            if (ModelState.IsValid)
            {
                DAL obj = new DAL();
                BookAppointment b = new BookAppointment();
                b.AccepterId = (int)Session["aid"];
                b.CaseId = ba.CaseId;
                b.Date = ba.Date;
                b.Slot = ba.Slot;
                b.Status = ba.Status;
                bool res = obj.BookAppointment(b);
                if (res == true)
                {
                    ViewBag.msg = "Appointment Registered successfully";
                }
                else
                {
                    ViewBag.msg = "errror";
                }
            }
            return View(ba);
        }
        public ActionResult ViewAppointment()
        {
            DAL obj = new DAL();
            ViewAppointment va = new ViewAppointment();
            List<ViewAppointment> VAList = obj.SeeAppointment(va);
            List<ViewAppointmentModel> VAMList = new List<ViewAppointmentModel>();
            foreach(ViewAppointment i in VAList)
            {
                ViewAppointmentModel vam = new ViewAppointmentModel();
                vam.CaseId = i.CaseId;
                vam.Slot = i.Slot;
                vam.Status = i.Status;
                vam.Bookingdate = i.BookingDate;
                VAMList.Add(vam);

            }
            return View(VAMList);

        }
        public ActionResult VerifyAppointment(int cid)
        {
            Session["cid"] = cid;
            VerifyAppointmentModel vam = new VerifyAppointmentModel();
            return View(vam);

        }
        [HttpPost]
        public ActionResult VerifyAppointment(VerifyAppointmentModel VAM)
        {
            
            DAL obj = new DAL();
           VerifyAppointment va = new VerifyAppointment();
            va.CaseId = (int)Session["cid"];
            va.Status = VAM.status;
       
            bool res = obj.UpdateAppiontmentStatus(va);
            if (res == true)
            {
                ViewBag.msg = "Succeed.....";
            }
            else
            {
                ViewBag.msg = "Failed......";

            }
            return View(VAM);
           
        }
       
    }
}