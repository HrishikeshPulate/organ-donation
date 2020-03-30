using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace organ_donation.Models
{
    public class ViewDoctorModel
    {
        public int DoctorId { get; set; }
        public List<SelectListItem> DocList = new List<SelectListItem>();
    }
    
}