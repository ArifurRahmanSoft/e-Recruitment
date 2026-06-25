using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobRecruitmentApprovalFlow
    {
        public decimal Oid { get; set; }
        public string? ApplicantId { get; set; }
        public string? Isprepared { get; set; }
        public string? PreparedBy { get; set; }
        public string? PreparedNote { get; set; }
        public DateTime? PreparedDate { get; set; }
        public string? Ishrbp { get; set; }
        public string? HrbpBy { get; set; }
        public string? HrbpNote { get; set; }
        public DateTime? HrbpDate { get; set; }
        public string? Ishounit { get; set; }
        public string? HounitBy { get; set; }
        public string? HounitNote { get; set; }
        public DateTime? HounitDate { get; set; }
        public string? Ishobusiness { get; set; }
        public string? HobusinessBy { get; set; }
        public string? HobusinessNote { get; set; }
        public DateTime? HobusinessDate { get; set; }
        public string? IsFapprove { get; set; }
        public string? FapproveBy { get; set; }
        public string? FapproveNote { get; set; }
        public DateTime? FapproveDate { get; set; }
        public string? RecruitmentCklstOid { get; set; }
    }
}
