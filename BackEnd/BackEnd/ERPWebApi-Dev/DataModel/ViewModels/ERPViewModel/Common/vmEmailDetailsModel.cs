using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel.ViewModels.ERPViewModel.Common
{
    public class vmEmailDetailsModel
    {
        public string toEmail { get; set; }
        public string mailType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string loggedUserId { get; set; }
        public string applicantId { get; set; }
        public string profileId { get; set; }
        public string jobId { get; set; }
        public string name { get; set; }
        public string CompanyName { get; set; }
        public string department { get; set; }
        public string post { get; set; }
        public string Address { get; set; }
        public string jobTitle { get; set; }
        public string nid { get; set; }
        public string examDate { get; set; }
        public string examHour { get; set; }
    }
   
}
