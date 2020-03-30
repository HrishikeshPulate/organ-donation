using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace organ_donation.Models
{
    public class BookAppointmentModel
    {
        public int AccepterId { get; set; }
        public int CaseId { get; set; }
        public string Status { get; set; }
        public string Slot { get; set; }
        public DateTime Date { get; set; }
        public List<SelectListItem> SlotList = new List<SelectListItem>();
        public BookAppointmentModel()
        {
            SlotList.Add(new SelectListItem() { Text = "9AM-11AM", Value = "9AM-11AM" });
            SlotList.Add(new SelectListItem() { Text = "12PM-2PM", Value = "12PM-2PM" });
            SlotList.Add(new SelectListItem() { Text = "4PM-6PM", Value = "4PM-6PM" });

        }
    }

}