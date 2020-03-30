using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace organ_donation.Models
{
    public class CasePoolViewModel
    {
        public int CaseId { get; set; }
        public string AccepterId { get; set; }
        public string DoctorId { get; set; }
        public int DonorId { get; set; }
        public string Organs { get; set; }
        public string Status { get; set; }
    }
}