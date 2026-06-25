using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TJobApplicantMainMaster
    {
        public string Oid { get; set; } = null!;
        public string? Jobid { get; set; }
        public string? Profileoid { get; set; }
        public DateTime? Applydate { get; set; }
        public string? ApplicantCode { get; set; }
        public string? Email { get; set; }
        public string? OfficialMsg { get; set; }
        public string? Isactive { get; set; }
        public string? Isdelete { get; set; }
        public string? Iswritten { get; set; }
        public string? Isviva { get; set; }
        public string? Isselected { get; set; }
        public DateTime? WrittenDate { get; set; }
        public DateTime? VivaDate { get; set; }
        public DateTime? SelectedDate { get; set; }
        public string? Isjoining { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? SetSalary { get; set; }
        public string? Isverify { get; set; }
        public string? Verifyby { get; set; }
        public DateTime? VerifyDate { get; set; }
        public string? Isverifydecline { get; set; }
        public string? Vdeclvby { get; set; }
        public DateTime? Vdeclndate { get; set; }
        public string? Verifydecnote { get; set; }
        public string? Isapprove { get; set; }
        public string? Approveby { get; set; }
        public DateTime? Approvedate { get; set; }
        public string? Isaprvdecln { get; set; }
        public string? Aprvdeclnby { get; set; }
        public DateTime? Aprvdeclndate { get; set; }
        public string? Approvedecnote { get; set; }
        public string? EmpOid { get; set; }
        public string? IsAprvrevision { get; set; }
        public string? AprvrevisionBy { get; set; }
        public DateTime? AprvrevisionDate { get; set; }
        public string? AprvrevNote { get; set; }
    }
}
