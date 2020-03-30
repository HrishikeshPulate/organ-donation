using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace organ_donation.Models
{
    public class VerifyDonorModel
    {
        public string status { get; set; }
        public string Orgon { get; set; }
        public List<SelectListItem> StatusList = new List<SelectListItem>();
        public List<SelectListItem> OList = new List<SelectListItem>();
        public VerifyDonorModel()
        {
            StatusList.Add(new SelectListItem() { Text = "Verified", Value = "Verified" });
            StatusList.Add(new SelectListItem() { Text = "Rejected", Value = "Rejected" });

            OList.Add(new SelectListItem() { Text = "Eyes", Value = "Eyes" });
            OList.Add(new SelectListItem() { Text = "Kidneys", Value = "Kidneys" });
            OList.Add(new SelectListItem() { Text = "Liver", Value = "Liver" });
            OList.Add(new SelectListItem() { Text = "Lungs", Value = "Lungs" });
            OList.Add(new SelectListItem() { Text = "Intestine", Value = "Intestine" });
        }
    }
}