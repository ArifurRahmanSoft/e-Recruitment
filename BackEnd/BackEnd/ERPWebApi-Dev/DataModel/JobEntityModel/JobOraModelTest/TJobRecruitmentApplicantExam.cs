using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobRecruitmentApplicantExam
    {
        public string Oid { get; set; } = null!;
        public string ReqAprvOid { get; set; } = null!;
        public string? Examtype { get; set; }
        public string? Isattend { get; set; }
        public string? Location { get; set; }
        public string? Examinar { get; set; }
        public DateTime? ExamDate { get; set; }
        public decimal? ExamMarks { get; set; }
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
        public string? Isselected { get; set; }
    }
}
