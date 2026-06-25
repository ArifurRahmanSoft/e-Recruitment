using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobApplicantReference
    {
        public string Oid { get; set; } = null!;
        public string? Referencecode { get; set; }
        public string? Name { get; set; }
        public string? Organization { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Relation { get; set; }
        public string? Isactive { get; set; }
        public string? Isdelete { get; set; }
        public string? Createpc { get; set; }
        public string? Createby { get; set; }
        public DateTime? Creation { get; set; }
        public string? Updatepc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updation { get; set; }
        public string? Deletepc { get; set; }
        public DateTime? Deletion { get; set; }
        public string? Deleteby { get; set; }
        public string? ApplicantOid { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
    }
}
