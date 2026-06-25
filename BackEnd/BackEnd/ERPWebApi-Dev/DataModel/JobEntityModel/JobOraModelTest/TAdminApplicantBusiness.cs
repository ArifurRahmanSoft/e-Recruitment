using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TAdminApplicantBusiness
    {
        public string Oid { get; set; } = null!;
        public decimal? Numid { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public string? Isactive { get; set; }
        public string? Iscancel { get; set; }
        public string? Createby { get; set; }
        public DateTime? Creation { get; set; }
        public string? Createpc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updation { get; set; }
        public string? Updatepc { get; set; }
        public string? Deleteby { get; set; }
        public string? Deletion { get; set; }
        public DateTime? Delation { get; set; }
        public string? Delatepc { get; set; }
    }
}
