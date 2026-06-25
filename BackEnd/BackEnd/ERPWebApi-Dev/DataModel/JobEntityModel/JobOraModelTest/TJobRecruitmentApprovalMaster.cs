using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobRecruitmentApprovalMaster
    {
        public string Oid { get; set; } = null!;
        public string? Jobid { get; set; }
        public string? Profileoid { get; set; }
        public string? Applicantoid { get; set; }
        public string? Linemanager { get; set; }
        public string? Salary { get; set; }
        public string? Designation { get; set; }
        public string? SalaryGrade { get; set; }
        public string? SalaryReviewer { get; set; }
        public string? BonusType { get; set; }
        public string? Ispf { get; set; }
        public string? Isincrement { get; set; }
        public string? Issim { get; set; }
        public string? Isdormitory { get; set; }
        public string? Istransport { get; set; }
        public string? Ismedical { get; set; }
        public string? Isinsurance { get; set; }
        public string? JobType { get; set; }
        public string? JobRole { get; set; }
        public string? PreparedBy { get; set; }
        public string? Hrbp { get; set; }
        public string? HeadofUnit { get; set; }
        public string? HeadofBusinessUnit { get; set; }
        public string? FinalApprove { get; set; }
        public string? Createdby { get; set; }
        public string? Createdpc { get; set; }
        public DateTime? Creation { get; set; }
        public string? Updatedby { get; set; }
        public string? Updatedpc { get; set; }
        public DateTime? Updation { get; set; }
        public string? Deleteby { get; set; }
        public string? Deletepc { get; set; }
        public DateTime? Deletion { get; set; }
        public string? RequsitionOid { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Isactive { get; set; }
        public string? Iscancel { get; set; }
        public string? IsFinalApprove { get; set; }
    }
}
