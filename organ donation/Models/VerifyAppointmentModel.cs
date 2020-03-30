using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace organ_donation.Models
{
    public class VerifyAppointmentModel
    {
        public string status { get; set; }
        
        public List<SelectListItem> StatusList = new List<SelectListItem>();
     
        public VerifyAppointmentModel()
        {
            StatusList.Add(new SelectListItem() { Text = "Confirmed", Value = "Confirmed" });
            StatusList.Add(new SelectListItem() { Text = "Rejected", Value = "Rejected" });
                      
        }
    }
}