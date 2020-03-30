using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organ_donation.Models
{
    public class NomineeViewModel
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
}