using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobApplicantExperience
    {
        public string Oid { get; set; } = null!;
        public string Experienceid { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? CompanyType { get; set; }
        public string? PriodFromDate { get; set; }
        public string? PriodToDate { get; set; }
        public string? JobDescription { get; set; }
        public string? Department { get; set; }
        public string? Isactive { get; set; }
        public string? Isdelete { get; set; }
        public string? Createpc { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createon { get; set; }
        public string? Updatepc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updateon { get; set; }
        public string? Deletepc { get; set; }
        public string? Deleteby { get; set; }
        public DateTime? Deleteon { get; set; }
        public string? ApplicantOid { get; set; }
        public string? Designation { get; set; }
        public string? Location { get; set; }
        public string? Isrunning { get; set; }
        public string? Salary { get; set; }
        public string? Docname { get; set; }
        public decimal? Totaldaycount { get; set; }
        public string? IslastExperience { get; set; }
    }
}
