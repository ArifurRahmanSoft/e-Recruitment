using System;
using System.Collections.Generic;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class TAdminApplicantExperience
    {
        public string Oid { get; set; } = null!;
        public decimal? Numid { get; set; }
        public string? JobpostOid { get; set; }
        public string? Experience { get; set; }
        public string? Isactive { get; set; }
        public string? Iscancel { get; set; }
    }
}
