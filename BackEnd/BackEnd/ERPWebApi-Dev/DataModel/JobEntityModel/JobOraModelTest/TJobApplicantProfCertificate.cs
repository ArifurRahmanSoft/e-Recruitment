using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobApplicantProfCertificate
    {
        public string Oid { get; set; } = null!;
        public string? Certificatecode { get; set; }
        public string? CourseName { get; set; }
        public string? Institution { get; set; }
        public string? StartDate { get; set; }
        public DateTime? AchievmentDate { get; set; }
        public string? Isactive { get; set; }
        public string? Isdelete { get; set; }
        public string? Createpc { get; set; }
        public string? Createby { get; set; }
        public DateTime? Creation { get; set; }
        public string? Updatepc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updation { get; set; }
        public string? Deletepc { get; set; }
        public string? Deleteby { get; set; }
        public DateTime? Deletion { get; set; }
        public string? ApplicantOid { get; set; }
        public string? Docname { get; set; }
    }
}
