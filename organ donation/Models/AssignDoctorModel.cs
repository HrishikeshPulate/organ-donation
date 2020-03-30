using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace organ_donation.Models
{
    public class AssignDoctorModel
    {
        [Required]
        public int DoctorId { get; set; }
        //public int cid { get; set; }
    }
}