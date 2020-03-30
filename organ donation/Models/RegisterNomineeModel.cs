using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace organ_donation.Models
{
    public class RegisterNomineeModel
    {
        [Required]
        public string NomineeName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8)]
        public string pwd { get; set; }
        [Required]
        [StringLength(8)]
        public string CPwd { get; set; }
        [Required]
        public string DonorName { get; set; }
        [Required]
        
        public int DonorAge { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string DonorGender { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public string Contact { get; set; }
        
        public List<SelectListItem> AgeList = new List<SelectListItem>();
        public List<SelectListItem> GenList = new List<SelectListItem>();
        public List<SelectListItem> LocList = new List<SelectListItem>();
        public List<SelectListItem> BGList = new List<SelectListItem>();

        public RegisterNomineeModel ()
        {
            for(int i=18;i<=50;i++)
            {
                AgeList.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
            GenList.Add(new SelectListItem() { Text = "MALE", Value = "MALE" });
            GenList.Add(new SelectListItem() { Text = "FEMALE", Value = "FEMALE" });
            GenList.Add(new SelectListItem() { Text = "TRANSGENDER", Value = "TRANSGENDER" });

            LocList.Add(new SelectListItem() { Text = "Chennai", Value = "Chennai" });
            LocList.Add(new SelectListItem() { Text = "Pune", Value = "Pune" });
            LocList.Add(new SelectListItem() { Text = "Mumbai", Value = "Mumbai" });
            LocList.Add(new SelectListItem() { Text = "Banglore", Value = "Banglore" });
            LocList.Add(new SelectListItem() { Text = "Delhi", Value = "Delhi" });

            BGList.Add(new SelectListItem() { Text = "A+", Value = "A+" });
            BGList.Add(new SelectListItem() { Text = "A-", Value = "A-" });
            BGList.Add(new SelectListItem() { Text = "B+", Value = "B+" });
            BGList.Add(new SelectListItem() { Text = "B-", Value = "B-" });
            BGList.Add(new SelectListItem() { Text = "O+", Value = "O+" });
            BGList.Add(new SelectListItem() { Text = "O-", Value = "O-" });
            BGList.Add(new SelectListItem() { Text = "AB+", Value = "AB+" });
            BGList.Add(new SelectListItem() { Text = "AB-", Value = "AB-" });
        }

        
       



    }
}