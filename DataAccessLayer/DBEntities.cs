using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LoginDetails
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
    public class RegisterNominee
    {

        public string NomineeName { get; set; }
        public string Username { get; set; }
        public string pwd { get; set; }
        public string CPwd { get; set; }
        public string DonorName { get; set; }
        public int DonorAge { get; set; }
        public DateTime Date { get; set; }
        public string DonorGender { get; set; }
        public string Location { get; set; }
        public string BloodGroup { get; set; }
        public string Contact { get; set; }
    }
    public class RegisterAccepter
    {
        public string AccepterName { get; set; }
        public string Username { get; set; }
        public string pwd { get; set; }
        public string CPwd { get; set; }
        public string RequirementOrgon { get; set; }
        public int AccepterAge { get; set; }
        public DateTime Date { get; set; }
        public string DonorGender { get; set; }
        public string Location { get; set; }
        public string BloodGroup { get; set; }
        public string Contact { get; set; }

    }
    public class ViewCasePool
    {
        public int CaseId { get; set; }
        public string AccepterId { get; set; }
        public string DoctorId { get; set; }
        public int DonorId { get; set; }
        public string Organs { get; set; }
        public string Status { get; set; }
    }
    public class ViewDoctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
       
    }
    public class AssignDoctor
    {
        public int DoctorId { get; set; }
        public int cid { get; set; }
    }
    public class ViewDonor
    {
        public int DonorId { get; set; }
        public string DonorName { get; set; }
    }
    public class VerifyDonor
    {
        public string Status { get; set; }
        public int CaseId { get; set; }
        public string Orgon { get; set; }
    }
    public class NomineeView
    {
        public string NomineeName { get; set; }
        public string DonorName { get; set; }
        public int DonorAge { get; set; }
        public DateTime Date { get; set; }
        public string DonorGender { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string BloodGroup { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
    }
    public class AccepterView
    {
        public int AccepterId { get; set; }
        public string AccepterName { get; set; }
        public string Requirement { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string BloodGroup { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
    }
    public class ViewAppointment

    {
        public int CaseId { get; set; }
        public string Status { get; set; }
        public string Slot { get; set; }
        public DateTime BookingDate { get; set; } 
    }
   public class VerifyAppointment
    {
        public string Status { get; set; }
        public int CaseId { get; set; }
       
    }
    public class BookAppointment
    {
        public int AccepterId { get; set; }
        public int CaseId { get; set; }
        public string Status { get; set; }
        public string Slot { get; set; }
        public DateTime Date { get; set; }
    }



}
