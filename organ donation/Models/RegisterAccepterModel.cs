using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace organ_donation.Models
{
    public class RegisterAccepterModel
    {


        [Required]
        public string NAME { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8)]
        public string pwd { get; set; }
        [Required]
        [StringLength(8)]
        public string CPwd { get; set; }
        [Required]
        public string REQUIREMENT { get; set; }
        [Required]
        public int AGE { get; set; }
        [Required]
        public DateTime DATE { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string LOCATION { get; set; }
        [Required]
        public string BLOOD_GROUP { get; set; }
        [Required]
        public string CONTACT_NUMBER { get; set; }
        public List<SelectListItem> OList = new List<SelectListItem>();
        public List<SelectListItem> AgeList = new List<SelectListItem>();
        public List<SelectListItem> GenList = new List<SelectListItem>();
        public List<SelectListItem> LocList = new List<SelectListItem>();
        public List<SelectListItem> BGList = new List<SelectListItem>();
        public RegisterAccepterModel()
        {
            OList.Add(new SelectListItem() { Text = "Eyes", Value = "Eyes" });
            OList.Add(new SelectListItem() { Text = "Kidneys", Value = "Kidneys" });
            OList.Add(new SelectListItem() { Text = "Liver", Value = "Liver" });
            OList.Add(new SelectListItem() { Text = "Lungs", Value = "Lungs" });
            OList.Add(new SelectListItem() { Text = "Intestine", Value = "Intestine" });

            for (int i = 18; i <= 50; i++)
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