using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobApplicantTraining
    {
        public string Oid { get; set; } = null!;
        public string? Trainingcode { get; set; }
        public string? TrainingName { get; set; }
        public string? Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Isactive { get; set; }
        public string? Isdelete { get; set; }
        public string? Createpc { get; set; }
        public string? Createby { get; set; }
        public DateTime? Creation { get; set; }
        public string? Updatepc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updation { get; set; }
        public string? Deletepc { get; set; }
        public string? ApplicantOid { get; set; }
        public string? Docname { get; set; }
        public string? Deletion { get; set; }
        public string? Deleteby { get; set; }
    }
}
