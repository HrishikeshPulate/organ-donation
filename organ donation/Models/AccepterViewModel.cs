using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organ_donation.Models
{
    public class AccepterViewModel
    {
       
        public int ACEEPTER_ID { get; set; }
      
        public string NAME { get; set; }
       
        public string REQUIREMENT { get; set; }
       
        public int AGE { get; set; }
       
        public DateTime DATE { get; set; }
       
        public string GENDER { get; set; }
        
        public string LOCATION { get; set; }
       
        public string BLOOD_GROUP { get; set; }
     
        public string CONTACT_NUMBER { get; set; }
       
        public string STATUS { get; set; }
       
        public int UserId { get; set; }
       
    }
}