using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobRecruitmentExaminer
    {
        public string Oid { get; set; } = null!;
        public string AempOid { get; set; } = null!;
        public string EmpId { get; set; } = null!;
        public string? Createpc { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createon { get; set; }
        public string? Updatepc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updateon { get; set; }
        public string? Deletepc { get; set; }
        public string? Deleteby { get; set; }
        public DateTime? Deleteon { get; set; }
        public string? Isdelete { get; set; }
        public string? Isactive { get; set; }
    }
}
