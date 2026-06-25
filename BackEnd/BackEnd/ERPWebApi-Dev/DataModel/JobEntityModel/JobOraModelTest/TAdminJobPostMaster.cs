using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TAdminJobPostMaster
    {
        public string Oid { get; set; } = null!;
        public decimal Numid { get; set; }
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public string? Department { get; set; }
        public string? Post { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public string? Workplace { get; set; }
        public string? EmployeementStatus { get; set; }
        public string? JobLocation { get; set; }
        public string? Criteria { get; set; }
        public string? Address { get; set; }
        public string? Business { get; set; }
        public string? SalaryRange { get; set; }
        public string? Isactive { get; set; }
        public string? Iscancel { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createon { get; set; }
        public string? Createpc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updateon { get; set; }
        public string? Updatepc { get; set; }
        public string? Cancelby { get; set; }
        public DateTime? Cancelon { get; set; }
        public string? Cancelpc { get; set; }
        public string? JobDescription { get; set; }
        public string? ReqOid { get; set; }
    }
}
