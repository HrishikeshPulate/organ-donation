using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organ_donation.Models
{
    public class ViewAppointmentModel
    {
      public int CaseId { get; set; }
        public string Status { get; set; }
        public string Slot { get; set; }
        public DateTime Bookingdate { get; set; }

    }
}