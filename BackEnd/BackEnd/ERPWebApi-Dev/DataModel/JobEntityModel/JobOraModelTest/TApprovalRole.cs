using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TApprovalRole
    {
        public string? RoleName { get; set; }
        public decimal RoleId { get; set; }
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Createdby { get; set; }
        public string? Updatedby { get; set; }
        public decimal Oid { get; set; }
        public string? Isactive { get; set; }
        public string? Isdelete { get; set; }
    }
}
