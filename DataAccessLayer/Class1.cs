using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL
    {
        public LoginDetails VerifyLogin(string un, string pwd)
        {
            LoginDetails det = null;
            try
            {
                EF_Database ctx = new EF_Database();

                var res = (from obj in ctx.Userinfos
                           where obj.USER_NAME == un && obj.PASSWORD == pwd
                           select new { obj.USER_ID, obj.RoleId, obj.USER_NAME }).FirstOrDefault();
                if (res != null)
                {
                    det = new LoginDetails();
                    det.UserName = res.USER_NAME;
                    det.UserID = res.USER_ID;
                    det.RoleID = res.RoleId;

                }
            }
            catch(Exception e)
            {
                throw new Exception("Error Occured During Login");
            }
            return det;
        }
        public bool EnterNomineeData(RegisterNominee RN)
        {
            //Store Nominee data into database
            bool flag = false;
            try
            {

                EF_Database ctx = new EF_Database();
                Nominee N = new Nominee();
                N.NOMINEE_NAME = RN.NomineeName;
                N.DONOR_NAME = RN.DonorName;
                N.DONOR_AGE = RN.DonorAge;
                N.DATE = DateTime.Now;
                N.DONOR_GENDER = RN.DonorGender;
                N.LOCATION = RN.Location;
                N.BLOOD_GROUP = RN.BloodGroup;
                N.CONTACT_NUMBER = RN.Contact;
                N.STATUS = "Submited";

                Userinfo UI = new Userinfo();
                UI.USER_NAME = RN.Username;
                UI.PASSWORD = RN.CPwd;
                UI.RoleId = 3;
                N.USER_ID = UI;
                ctx.Nominees.Add(N);

                CasePool c = new CasePool();
                c.DonorId = N.NOMINEE_ID;
                c.STATUS = "Initiated";


                ctx.CasePools.Add(c);
                //ctx.Userinfos.Add(UI);
                ctx.SaveChanges();
                flag = true;
               
            }
            catch(Exception e)
            {
                // Error.Message = e.Message;
                throw new Exception("Error during Registering new Nominee");

            }

            return flag;
        }
       
        public bool EnterAccepterData(RegisterAccepter RA)
        {
            //Store Accepter Data To Database
            bool flag = false;
            try
            {
                EF_Database ctx = new EF_Database();
                Accepter a = new Accepter();
                a.NAME = RA.AccepterName;
                a.REQUIREMENT = RA.RequirementOrgon;
                a.AGE = RA.AccepterAge;
                a.BLOOD_GROUP = RA.BloodGroup;
                a.CONTACT_NUMBER = RA.Contact;
                a.DATE = DateTime.Now;
                a.GENDER = RA.DonorGender;
                a.LOCATION = RA.Location;
                a.STATUS = "Requested";

                Userinfo UI = new Userinfo();
                UI.USER_NAME = RA.Username;
                UI.PASSWORD = RA.CPwd;
                UI.RoleId = 4;                
                a.USER_ID = UI;               
                ctx.Accepters.Add(a);
                ctx.SaveChanges();
                flag = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error during Registering new Accepter");
            }
            return flag;


        }

        public List<ViewCasePool> RetriveCaseData()
        {
            try
            {
                List<ViewCasePool> CpList = new List<ViewCasePool>();
                EF_Database ctx = new EF_Database();
                var res = from i in ctx.CasePools select i;
                foreach (var obj in res)
                {
                    ViewCasePool vcp = new ViewCasePool();
                    vcp.CaseId = obj.CASE_ID;
                    vcp.AccepterId = obj.AccepterId.HasValue ? obj.AccepterId.Value.ToString() : "NA";
                    vcp.DoctorId = obj.DoctorId.HasValue ? obj.DoctorId.Value.ToString() : "NA";        //ternary Operator
                    vcp.DonorId = obj.DonorId;          //modified Code            /*.HasValue ? obj.DonorId.Value.ToString() : "NA";*/
                    vcp.Organs = obj.ORGANS != null ? obj.ORGANS : "NA";
                    vcp.Status = obj.STATUS;
                    CpList.Add(vcp);
                }
                return CpList;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
           
        }
        public List<ViewCasePool> DoctorCaseData(int uid)
        {
            try
            {
                List<ViewCasePool> CpList = new List<ViewCasePool>();
                EF_Database ctx = new EF_Database();
                int did = (from i in ctx.Doctors where i.UserId == uid select i.DOCTOR_ID).FirstOrDefault();
                var res = from i in ctx.CasePools where i.DoctorId == did select i;

                foreach (var obj in res)
                {
                    ViewCasePool vcp = new ViewCasePool();
                    vcp.CaseId = obj.CASE_ID;
                    vcp.AccepterId = obj.AccepterId.HasValue ? obj.AccepterId.Value.ToString() : "NA";
                    vcp.DoctorId = obj.DoctorId.HasValue ? obj.DoctorId.Value.ToString() : "NA";        //ternary Operator
                    vcp.DonorId = obj.DonorId;          //modified Code            /*.HasValue ? obj.DonorId.Value.ToString() : "NA";*/
                    vcp.Organs = obj.ORGANS != null ? obj.ORGANS : "NA";
                    vcp.Status = obj.STATUS;
                    CpList.Add(vcp);
                }
                return CpList;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
        }

        public List<ViewDoctor> RetreiveDoctors()               //this is for Drop Down List
        {
            try
            {
                List<ViewDoctor> DList = new List<ViewDoctor>();
                EF_Database ctx = new EF_Database();
                var res = from i in ctx.Doctors select i;
                foreach (var obj in res)
                {
                    ViewDoctor doc = new ViewDoctor();
                    doc.DoctorId = obj.DOCTOR_ID;
                    doc.DoctorName = obj.DOCTOR_NAME;
                    DList.Add(doc);
                }
                return DList;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
        }
        public bool AssignAccepter(int cid)
        {
            bool flag = false;
            try
            {
                EF_Database ctx = new EF_Database();
                var res = ctx.CasePools.Where(i => i.CASE_ID == cid).Select(i => i).FirstOrDefault();
                var re1 = ctx.Accepters.OrderByDescending(i => i.DATE).Where(i => i.STATUS != "Assigned").Select(i => i).FirstOrDefault();
                var re2 = ctx.Nominees.Where(i => i.NOMINEE_ID == res.DonorId).Select(i => i).FirstOrDefault();
                if (res.AccepterId != 0)
                {
                    res.AccepterId = re1.ACEEPTER_ID;
                    re2.STATUS = "Accepter Assigned";
                    res.STATUS = re1.STATUS = "Assigned";
                }
                //var re2=ctx.Accepters.Where(i=>i.ACEEPTER_ID==res.AccepterId)
                ctx.SaveChanges();
                flag = true;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
            return flag;
        }
        public bool AssignDoctor(AssignDoctor AsDoc)
        {
            bool flag = false;
            try
            {
                EF_Database ctx = new EF_Database();
                CasePool c = new CasePool();
                var res = ctx.CasePools.Where(i => i.CASE_ID == AsDoc.cid).Select(i => i).FirstOrDefault();
                res.DoctorId = AsDoc.DoctorId;
                res.STATUS = "Assigned";
                var obj = ctx.Nominees.Where(i => i.NOMINEE_ID == res.DonorId).Select(i => i).FirstOrDefault();
                obj.STATUS = "Assigned";
                ctx.SaveChanges();
                flag = true;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
            return flag;
        }
        public bool UpdateVerificationStatus(VerifyDonor VerDon)
        {
            bool flag = false;
            try
            {
                
                EF_Database ctx = new EF_Database();
                CasePool c = new CasePool();
                var res = ctx.CasePools.Where(i => i.CASE_ID == VerDon.CaseId).Select(i => i).FirstOrDefault();
                var re1 = ctx.Nominees.Where(i => i.NOMINEE_ID == res.DonorId).Select(i => i).FirstOrDefault();
                re1.STATUS = VerDon.Status;
                res.STATUS = VerDon.Status;
                if (res.STATUS == "Verified")
                {

                    res.ORGANS = VerDon.Orgon;
                }

                ctx.SaveChanges();
                flag = true;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
            return flag;
        }
      
        public List<NomineeView> GetNominee(NomineeView nvi)
        {
            try
            {
                List<NomineeView> NList = new List<NomineeView>();
                EF_Database ctx = new EF_Database();
                var res = (from i in ctx.Nominees where i.UserId == nvi.UserId select i);
                foreach (Nominee obj in res)
                {
                    NomineeView nv = new NomineeView();
                    nv.BloodGroup = obj.BLOOD_GROUP;
                    nv.Contact = obj.CONTACT_NUMBER;
                    nv.Date = obj.DATE;
                    nv.DonorAge = obj.DONOR_AGE;
                    nv.DonorGender = obj.DONOR_GENDER;
                    nv.DonorName = obj.DONOR_NAME;
                    nv.Location = obj.LOCATION;
                    nv.NomineeName = obj.NOMINEE_NAME;
                    nv.Status = obj.STATUS;
                    nv.UserId = obj.UserId;
                    NList.Add(nv);
                }
                return NList;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
        }
        public List<AccepterView> GetAccepter(AccepterView avi)
        {
            try
            {
                List<AccepterView> AList = new List<AccepterView>();
                EF_Database ctx = new EF_Database();
                var res = (from i in ctx.Accepters where i.UserId == avi.UserId select i);
                foreach (Accepter obj in res)
                {
                    AccepterView av = new AccepterView();
                    av.AccepterId = obj.ACEEPTER_ID;
                    av.AccepterName = obj.NAME;
                    av.Requirement = obj.REQUIREMENT;
                    av.Gender = obj.GENDER;
                    av.Contact = obj.CONTACT_NUMBER;
                    av.BloodGroup = obj.BLOOD_GROUP;
                    av.Date = obj.DATE;
                    av.Location = obj.LOCATION;
                    av.Status = obj.STATUS;
                    av.Age = obj.AGE;
                    AList.Add(av);
                }
                return AList;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
        }
        public bool BookAppointment(BookAppointment ba)
        {
            bool flag = false;
            try
            {
                EF_Database ctx = new EF_Database();
                Appointment a = new Appointment();
                a.BOOKING_DATE = ba.Date;
                var res = ctx.CasePools.Where(i => i.AccepterId == ba.AccepterId).Select(i => i).FirstOrDefault();
                a.CaseId = res.CASE_ID;
                a.SLOT = ba.Slot;
                a.STATUS = "Initiated";
                var re1 = ctx.Accepters.Where(i => i.ACEEPTER_ID == ba.AccepterId).Select(i => i).FirstOrDefault();
                res.STATUS = re1.STATUS = "Booked";
                ctx.Appointments.Add(a);
                ctx.SaveChanges();
                flag = true;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
            return flag;
        }


        public List<ViewAppointment> SeeAppointment(ViewAppointment va)
        {
            //TO show data Of Appointment From Database
            try
            {
                List<ViewAppointment> VAList = new List<ViewAppointment>();
                EF_Database ctx = new EF_Database();
                var res = from i in ctx.Appointments select i;
                foreach (var i in res)
                {
                    ViewAppointment a = new ViewAppointment();
                    a.CaseId = i.CaseId;
                    a.Slot = i.SLOT;
                    a.Status = i.STATUS;
                    a.BookingDate = i.BOOKING_DATE;
                    VAList.Add(a);
                }
                return VAList;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
        }
        public bool UpdateAppiontmentStatus(VerifyAppointment VA)
        {
            bool flag = false;
            try
            {
                EF_Database ctx = new EF_Database();
                var res = ctx.Appointments.Where(m => m.CaseId == VA.CaseId).Select(i => i).FirstOrDefault();

                var res2 = ctx.CasePools.Where(m => m.CASE_ID == VA.CaseId).Select(m => m).FirstOrDefault();
                var res1 = ctx.Accepters.Where(m => m.ACEEPTER_ID == res2.AccepterId).Select(i => i).FirstOrDefault();

                res.STATUS = VA.Status;
                res1.STATUS = VA.Status;
                ctx.SaveChanges();
                flag = true;
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
            return flag;
        }
       
    }
}
