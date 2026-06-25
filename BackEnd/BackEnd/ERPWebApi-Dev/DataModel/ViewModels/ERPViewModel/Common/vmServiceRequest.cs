using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.ViewModels
{
    public class vmServiceRequest
    {
        public string SRVCID { get; set; }
        public string TRNNO { get; set; }
        public string TYPEID { get; set; }
        public string SUBJECT { get; set; }
        public string FORMID { get; set; }
        public string TRANSACTIONNO { get; set; }
        public string FIELDS { get; set; }
        public string NARRATION { get; set; }
        public string CREATEBY { get; set; }
        public string CREATEON { get; set; }
        public string FORMNAME { get; set; }
        public string TYPENAME { get; set; }
    }

    public class vmSrvcReqMail
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string MailCC { get; set; }
        public string NameFrom { get; set; }
        public string NameTo { get; set; }
        public string CreateBy { get; set; }
        public string CreateOn { get; set; }
        public string ResponseBy { get; set; }
        public string ResponseOn { get; set; }
        public string Status { get; set; }
        public string Designation { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public string Message4 { get; set; }
        public string Message5 { get; set; }
        public string examDate { get; set; }
        public string examHour { get; set; }
        public string jobTitle { get; set; }
        public string Company { get; set; }
        public string department { get; set; }
        public string post { get; set; }

    }

    public class FileDetails
    {
        public string DetailsOid { get; set; }
        public string DocName { get; set; }
    }

}
