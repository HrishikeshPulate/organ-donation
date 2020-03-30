using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace organ_donation.Models
{
    public class ViewDonorModel
    {
        public int DonorId { get; set; }
        public List<SelectListItem> DonorList = new List<SelectListItem>();
    }
}