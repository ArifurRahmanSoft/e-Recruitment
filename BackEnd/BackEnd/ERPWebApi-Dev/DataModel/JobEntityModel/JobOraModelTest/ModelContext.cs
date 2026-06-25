using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataModel.JobEntityModel.JobOraModelTest
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ATestNewTable> ATestNewTables { get; set; } = null!;
        public virtual DbSet<TAcqlf> TAcqlves { get; set; } = null!;
        public virtual DbSet<TAdminApplicantBenefit> TAdminApplicantBenefits { get; set; } = null!;
        public virtual DbSet<TAdminApplicantBusiness> TAdminApplicantBusinesses { get; set; } = null!;
        public virtual DbSet<TAdminApplicantExperience> TAdminApplicantExperiences { get; set; } = null!;
        public virtual DbSet<TAdminApplicantOtherRequirement> TAdminApplicantOtherRequirements { get; set; } = null!;
        public virtual DbSet<TAdminApplicantRequirement> TAdminApplicantRequirements { get; set; } = null!;
        public virtual DbSet<TAdminApplicantResponsibility> TAdminApplicantResponsibilities { get; set; } = null!;
        public virtual DbSet<TAdminApplicantSkill> TAdminApplicantSkills { get; set; } = null!;
        public virtual DbSet<TAdminJobPostMaster> TAdminJobPostMasters { get; set; } = null!;
        public virtual DbSet<TAemp> TAemps { get; set; } = null!;
        public virtual DbSet<TApprovalRole> TApprovalRoles { get; set; } = null!;
        public virtual DbSet<TCheckAuthorisedDetail> TCheckAuthorisedDetails { get; set; } = null!;
        public virtual DbSet<TCheckAuthorisedMaster> TCheckAuthorisedMasters { get; set; } = null!;
        public virtual DbSet<TCmnmenu> TCmnmenus { get; set; } = null!;
        public virtual DbSet<TCmnmenupermission> TCmnmenupermissions { get; set; } = null!;
        public virtual DbSet<TErrorLog> TErrorLogs { get; set; } = null!;
        public virtual DbSet<TJobAppAcaQualification> TJobAppAcaQualifications { get; set; } = null!;
        public virtual DbSet<TJobAppAddress> TJobAppAddresses { get; set; } = null!;
        public virtual DbSet<TJobAppApplicantForm> TJobAppApplicantForms { get; set; } = null!;
        public virtual DbSet<TJobAppCircular> TJobAppCirculars { get; set; } = null!;
        public virtual DbSet<TJobAppCv> TJobAppCvs { get; set; } = null!;
        public virtual DbSet<TJobAppExperience> TJobAppExperiences { get; set; } = null!;
        public virtual DbSet<TJobAppImage> TJobAppImages { get; set; } = null!;
        public virtual DbSet<TJobAppRegister> TJobAppRegisters { get; set; } = null!;
        public virtual DbSet<TJobAppSignature> TJobAppSignatures { get; set; } = null!;
        public virtual DbSet<TJobApplicantAcaQualification> TJobApplicantAcaQualifications { get; set; } = null!;
        public virtual DbSet<TJobApplicantDocument> TJobApplicantDocuments { get; set; } = null!;
        public virtual DbSet<TJobApplicantExperience> TJobApplicantExperiences { get; set; } = null!;
        public virtual DbSet<TJobApplicantMainMaster> TJobApplicantMainMasters { get; set; } = null!;
        public virtual DbSet<TJobApplicantMaster> TJobApplicantMasters { get; set; } = null!;
        public virtual DbSet<TJobApplicantProfCertificate> TJobApplicantProfCertificates { get; set; } = null!;
        public virtual DbSet<TJobApplicantReference> TJobApplicantReferences { get; set; } = null!;
        public virtual DbSet<TJobApplicantTraining> TJobApplicantTrainings { get; set; } = null!;
        public virtual DbSet<TJobCmnmenu> TJobCmnmenus { get; set; } = null!;
        public virtual DbSet<TJobEmployee> TJobEmployees { get; set; } = null!;
        public virtual DbSet<TJobRecruitmentApplicantExam> TJobRecruitmentApplicantExams { get; set; } = null!;
        public virtual DbSet<TJobRecruitmentApprovalFlow> TJobRecruitmentApprovalFlows { get; set; } = null!;
        public virtual DbSet<TJobRecruitmentApprovalMaster> TJobRecruitmentApprovalMasters { get; set; } = null!;
        public virtual DbSet<TJobRecruitmentExaminer> TJobRecruitmentExaminers { get; set; } = null!;
        public virtual DbSet<TJobRegister> TJobRegisters { get; set; } = null!;
        public virtual DbSet<TRoleSetup> TRoleSetups { get; set; } = null!;
        public virtual DbSet<TSysUser> TSysUsers { get; set; } = null!;
        public virtual DbSet<TTest> TTests { get; set; } = null!;
        public virtual DbSet<TUser> TUsers { get; set; } = null!;
        public virtual DbSet<TUserMenu> TUserMenus { get; set; } = null!;
        public virtual DbSet<TUserRole> TUserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=erpprd)(PORT=1525))(CONNECT_DATA=(SERVICE_NAME=hrdpdb)));User Id=hr_job_app;Password=hr_job_it;;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HR_JOB_APP")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<ATestNewTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("A_TEST_NEW_TABLE");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.DegreeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_NAME");

                entity.Property(e => e.Oid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OID");
            });

            modelBuilder.Entity<TAcqlf>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ACQLF_PK");

                entity.ToTable("T_ACQLF");

                entity.Property(e => e.Oid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.DegreeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_NAME");
            });

            modelBuilder.Entity<TAdminApplicantBenefit>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_BENEFITS_PK");

                entity.ToTable("T_ADMIN_APPLICANT_BENEFITS");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Benefits)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BENEFITS");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.JobpostOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBPOST_OID");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");
            });

            modelBuilder.Entity<TAdminApplicantBusiness>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_BUSINESS_PK");

                entity.ToTable("T_ADMIN_APPLICANT_BUSINESS");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Creation)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION");

                entity.Property(e => e.Delatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELATEPC");

                entity.Property(e => e.Delation)
                    .HasColumnType("DATE")
                    .HasColumnName("DELATION");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETION");

                entity.Property(e => e.Details)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DETAILS");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Updation)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATION");
            });

            modelBuilder.Entity<TAdminApplicantExperience>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_EXPERIENCE_PK");

                entity.ToTable("T_ADMIN_APPLICANT_EXPERIENCE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Experience)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EXPERIENCE");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 \n")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 \n")
                    .IsFixedLength();

                entity.Property(e => e.JobpostOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBPOST_OID");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");
            });

            modelBuilder.Entity<TAdminApplicantOtherRequirement>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_OTHER_REQUIREMRNT_PK");

                entity.ToTable("T_ADMIN_APPLICANT_OTHER_REQUIREMENT");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.JobpostOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBPOST_OID");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");

                entity.Property(e => e.Requirement)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REQUIREMENT");
            });

            modelBuilder.Entity<TAdminApplicantRequirement>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_REQUIREMRNT _PK");

                entity.ToTable("T_ADMIN_APPLICANT_REQUIREMENT");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.JobpostOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBPOST_OID");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");

                entity.Property(e => e.Requirement)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REQUIREMENT");
            });

            modelBuilder.Entity<TAdminApplicantResponsibility>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_RESPONSIBILITY_PK");

                entity.ToTable("T_ADMIN_APPLICANT_RESPONSIBILITY");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.JobpostOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBPOST_OID");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");

                entity.Property(e => e.Responsibility)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RESPONSIBILITY");
            });

            modelBuilder.Entity<TAdminApplicantSkill>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_APPLICANT_SKILL_PK");

                entity.ToTable("T_ADMIN_APPLICANT_SKILL");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.JobpostOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBPOST_OID");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");

                entity.Property(e => e.Skill)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SKILL");
            });

            modelBuilder.Entity<TAdminJobPostMaster>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_ADMIN_MASTER_PK");

                entity.ToTable("T_ADMIN_JOB_POST_MASTER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Business)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Criteria)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CRITERIA");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Education)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EDUCATION");

                entity.Property(e => e.EmployeementStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEEMENT_STATUS");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Experience)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EXPERIENCE");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.JobDescription)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DESCRIPTION");

                entity.Property(e => e.JobLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("JOB_LOCATION");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.Numid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMID");

                entity.Property(e => e.Post)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("POST");

                entity.Property(e => e.ReqOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REQ_OID");

                entity.Property(e => e.SalaryRange)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("SALARY_RANGE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Workplace)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WORKPLACE");
            });

            modelBuilder.Entity<TAemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_AEMP");

                entity.Property(e => e.AempAcmp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ACMP")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AempAcno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ACNO");

                entity.Property(e => e.AempActv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ACTV")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AempAdd1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ADD1");

                entity.Property(e => e.AempAdd2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ADD2");

                entity.Property(e => e.AempAddrTemp)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ADDR_TEMP");

                entity.Property(e => e.AempAfconAmnt)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("AEMP_AFCON_AMNT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AempArea)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_AREA");

                entity.Property(e => e.AempAtsc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ATSC")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AempBenam)
                    .HasMaxLength(200)
                    .HasColumnName("AEMP_BENAM");

                entity.Property(e => e.AempBfnam)
                    .HasMaxLength(200)
                    .HasColumnName("AEMP_BFNAM");

                entity.Property(e => e.AempBgrp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_BGRP");

                entity.Property(e => e.AempBmnam)
                    .HasMaxLength(200)
                    .HasColumnName("AEMP_BMNAM");

                entity.Property(e => e.AempBnam)
                    .HasMaxLength(100)
                    .HasColumnName("AEMP_BNAM");

                entity.Property(e => e.AempBrdt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_BRDT");

                entity.Property(e => e.AempBwnam)
                    .HasMaxLength(200)
                    .HasColumnName("AEMP_BWNAM");

                entity.Property(e => e.AempCidt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_CIDT");

                entity.Property(e => e.AempCndt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_CNDT");

                entity.Property(e => e.AempCnty)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_CNTY");

                entity.Property(e => e.AempCrdf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_CRDF")
                    .HasDefaultValueSql("'N'");

                entity.Property(e => e.AempCrdn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_CRDN");

                entity.Property(e => e.AempCrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_CRDR")
                    .HasDefaultValueSql("'N'");

                entity.Property(e => e.AempCrdt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_CRDT");

                entity.Property(e => e.AempDept)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_DEPT")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AempDist)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_DIST");

                entity.Property(e => e.AempDsig)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_DSIG")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AempEnam)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_ENAM")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AempFnam)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_FNAM");

                entity.Property(e => e.AempGndr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_GNDR");

                entity.Property(e => e.AempGrad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_GRAD")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AempGrty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_GRTY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AempJloc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_JLOC");

                entity.Property(e => e.AempJndt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_JNDT");

                entity.Property(e => e.AempLrno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_LRNO");

                entity.Property(e => e.AempMail1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_MAIL1");

                entity.Property(e => e.AempMdcl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_MDCL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AempMnam)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_MNAM");

                entity.Property(e => e.AempMobAllow)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("AEMP_MOB_ALLOW")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AempMobBrand)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_MOB_BRAND");

                entity.Property(e => e.AempMobIemi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_MOB_IEMI");

                entity.Property(e => e.AempMobn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_MOBN");

                entity.Property(e => e.AempOffcMobn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_OFFC_MOBN");

                entity.Property(e => e.AempOmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_OMAIL");

                entity.Property(e => e.AempOt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_OT")
                    .HasDefaultValueSql("'N'");

                entity.Property(e => e.AempPfafAcyl)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_PFAF_ACYL");

                entity.Property(e => e.AempPfdt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_PFDT");

                entity.Property(e => e.AempPfnd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_PFND")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AempPosf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_POSF")
                    .HasDefaultValueSql("'Y'");

                entity.Property(e => e.AempPprt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_PPRT");

                entity.Property(e => e.AempProb)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_PROB");

                entity.Property(e => e.AempRlgn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_RLGN");

                entity.Property(e => e.AempRndt)
                    .HasColumnType("DATE")
                    .HasColumnName("AEMP_RNDT");

                entity.Property(e => e.AempRsgnDesc)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_RSGN_DESC");

                entity.Property(e => e.AempRsgnNote)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_RSGN_NOTE");

                entity.Property(e => e.AempSalrStop)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_SALR_STOP")
                    .HasDefaultValueSql("'N'");

                entity.Property(e => e.AempScal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_SCAL");

                entity.Property(e => e.AempStat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_STAT");

                entity.Property(e => e.AempText)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_TEXT");

                entity.Property(e => e.AempTlno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_TLNO");

                entity.Property(e => e.AempTxno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_TXNO");

                entity.Property(e => e.AempType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_TYPE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AempUpzl)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_UPZL");

                entity.Property(e => e.AempVidn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_VIDN");

                entity.Property(e => e.AempWnam)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_WNAM");

                entity.Property(e => e.AlterId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALTER_ID");

                entity.Property(e => e.AltrMbno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ALTR_MBNO");

                entity.Property(e => e.AreaStat)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AREA_STAT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AuthMbno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AUTH_MBNO");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BANK_CODE");

                entity.Property(e => e.CashAmnt)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CASH_AMNT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CpvType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CPV_TYPE")
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.DailyAllow)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("DAILY_ALLOW")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DeptUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_UNIT");

                entity.Property(e => e.Edat)
                    .HasColumnType("DATE")
                    .HasColumnName("EDAT")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.Euser)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EUSER")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.GradNew)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GRAD_NEW");

                entity.Property(e => e.GradNewOid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GRAD_NEW_OID");

                entity.Property(e => e.Idat)
                    .HasColumnType("DATE")
                    .HasColumnName("IDAT")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.IncrAlwd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("INCR_ALWD")
                    .HasDefaultValueSql("'Y'");

                entity.Property(e => e.IpExt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IP_EXT");

                entity.Property(e => e.ItaxAcmp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ITAX_ACMP");

                entity.Property(e => e.ItaxCirc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITAX_CIRC");

                entity.Property(e => e.ItaxDist)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ITAX_DIST");

                entity.Property(e => e.ItaxZone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ITAX_ZONE");

                entity.Property(e => e.Iuser)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IUSER")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.PayMode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAY_MODE")
                    .HasDefaultValueSql("'CASH'");

                entity.Property(e => e.ProdDelvLoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROD_DELV_LOC");

                entity.Property(e => e.RecruitNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RECRUIT_NOTE");

                entity.Property(e => e.RecruitType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("RECRUIT_TYPE")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RefOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REF_OID");

                entity.Property(e => e.ReplaceId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("REPLACE_ID");

                entity.Property(e => e.SalrCons)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SALR_CONS")
                    .HasDefaultValueSql("'N'");

                entity.Property(e => e.SourceId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_ID");

                entity.Property(e => e.StopBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STOP_BY");

                entity.Property(e => e.StopDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STOP_DATE")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.StopFromAcyl)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STOP_FROM_ACYL");

                entity.Property(e => e.SupervId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SUPERV_ID");

                entity.Property(e => e.Udt)
                    .HasColumnType("DATE")
                    .HasColumnName("UDT")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.VehcleAllow)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("VEHCLE_ALLOW")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TApprovalRole>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_APPROVAL_ROLE_PK");

                entity.ToTable("T_APPROVAL_ROLE");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OID");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEDBY");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEDBY");

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<TCheckAuthorisedDetail>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_AUTHORISED_DETAIL_PK");

                entity.ToTable("T_CHECK_AUTHORISED_DETAIL");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.AccNo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO");

                entity.Property(e => e.AuthorisedOid)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("AUTHORISED_OID");

                entity.Property(e => e.CheckNo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CHECK_NO");

                entity.Property(e => e.TrNo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TR_NO");
            });

            modelBuilder.Entity<TCheckAuthorisedMaster>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_AUTHORISED_MASTER_PK");

                entity.ToTable("T_CHECK_AUTHORISED_MASTER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.ApproveBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPROVE_BY");

                entity.Property(e => e.ApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPROVE_DATE");

                entity.Property(e => e.AuthorisedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AUTHORISED_BY");

                entity.Property(e => e.AuthorisedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("AUTHORISED_DATE");

                entity.Property(e => e.Bank)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BANK");

                entity.Property(e => e.Company)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY");

                entity.Property(e => e.Isapprove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISAPPROVE")
                    .IsFixedLength();

                entity.Property(e => e.Isauthorised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISAUTHORISED")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.TrDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TR_DATE");
            });

            modelBuilder.Entity<TCmnmenu>(entity =>
            {
                entity.HasKey(e => e.Menuid)
                    .HasName("T_CMNMENU_PK");

                entity.ToTable("T_CMNMENU");

                entity.Property(e => e.Menuid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Issubparent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSUBPARENT")
                    .IsFixedLength();

                entity.Property(e => e.Menuicon)
                    .HasMaxLength(100)
                    .HasColumnName("MENUICON");

                entity.Property(e => e.Menuname)
                    .HasMaxLength(100)
                    .HasColumnName("MENUNAME");

                entity.Property(e => e.Menupath)
                    .HasMaxLength(300)
                    .HasColumnName("MENUPATH");

                entity.Property(e => e.Menushortname)
                    .HasMaxLength(100)
                    .HasColumnName("MENUSHORTNAME");

                entity.Property(e => e.Menutypeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUTYPEID");

                entity.Property(e => e.Moduleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MODULEID");

                entity.Property(e => e.Parentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARENTID");

                entity.Property(e => e.Sequence)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SEQUENCE");

                entity.Property(e => e.Subparentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SUBPARENTID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCmnmenupermission>(entity =>
            {
                entity.HasKey(e => e.Menupermissionid)
                    .HasName("T_JOB_CMNMENUPERMISSION_PK");

                entity.ToTable("T_CMNMENUPERMISSION");

                entity.Property(e => e.Menupermissionid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUPERMISSIONID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Enabledelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEDELETE")
                    .IsFixedLength();

                entity.Property(e => e.Enableinsert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEINSERT")
                    .IsFixedLength();

                entity.Property(e => e.Enableupdate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEUPDATE")
                    .IsFixedLength();

                entity.Property(e => e.Enableview)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEVIEW")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Menuid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUID");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TErrorLog>(entity =>
            {
                entity.HasKey(e => e.Errorid)
                    .HasName("T_ERROR_LOGS_PK");

                entity.ToTable("T_ERROR_LOGS");

                entity.Property(e => e.Errorid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ERRORID");

                entity.Property(e => e.Apipath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("APIPATH");

                entity.Property(e => e.Browser)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("BROWSER");

                entity.Property(e => e.Clientagent)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTAGENT");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Errormessage)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("ERRORMESSAGE");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("IPADDRESS");

                entity.Property(e => e.Requesttype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REQUESTTYPE");

                entity.Property(e => e.Spname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SPNAME");

                entity.Property(e => e.Stacktrace)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("STACKTRACE");
            });

            modelBuilder.Entity<TJobAppAcaQualification>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_ACA_QUALIFICATION");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantOid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.Board)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BOARD");

                entity.Property(e => e.Degree)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE");

                entity.Property(e => e.Degreetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEGREETYPE");

                entity.Property(e => e.Institution)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTION");

                entity.Property(e => e.Major)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAJOR");

                entity.Property(e => e.Passingyear)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PASSINGYEAR");

                entity.Property(e => e.Result)
                    .HasColumnType("NUMBER(4,2)")
                    .HasColumnName("RESULT");

                entity.HasOne(d => d.ApplicantO)
                    .WithMany(p => p.TJobAppAcaQualifications)
                    .HasForeignKey(d => d.ApplicantOid)
                    .HasConstraintName("FK_T_JOB_APP_ACA_QUALIFICATION_APPLICANT_OID");
            });

            modelBuilder.Entity<TJobAppAddress>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_ADDRESS");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantOid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.ParmAddDistrict)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARM_ADD_DISTRICT");

                entity.Property(e => e.ParmAddDivision)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARM_ADD_DIVISION");

                entity.Property(e => e.ParmAddPostOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARM_ADD_POST_OFFICE");

                entity.Property(e => e.ParmAddThana)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARM_ADD_THANA");

                entity.Property(e => e.ParmAddVillage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARM_ADD_VILLAGE");

                entity.Property(e => e.PersAddDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERS_ADD_DISTRICT");

                entity.Property(e => e.PresAddDivision)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRES_ADD_DIVISION");

                entity.Property(e => e.PresAddPostOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRES_ADD_POST_OFFICE");

                entity.Property(e => e.PresAddThana)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRES_ADD_THANA");

                entity.Property(e => e.PresAddVillage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRES_ADD_VILLAGE");

                entity.HasOne(d => d.ApplicantO)
                    .WithMany(p => p.TJobAppAddresses)
                    .HasForeignKey(d => d.ApplicantOid)
                    .HasConstraintName("FK_T_JOB_APP_ADDRESS_APPLICANT_OID");
            });

            modelBuilder.Entity<TJobAppApplicantForm>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_APPLICANT_FORM");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.AppliedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLIED_BY");

                entity.Property(e => e.AppliedPost)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLIED_POST");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPLY_DATE");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BIRTH_PLACE");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BLOOD_GROUP");

                entity.Property(e => e.CompanyDeptPost)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST");

                entity.Property(e => e.CompanyDeptPostActiveStatus)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST_ACTIVE_STATUS");

                entity.Property(e => e.CompanyDeptPostOpenDate)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST_OPEN_DATE");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CvId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CV_ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Department)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.ExpectedSelery)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPECTED_SELERY");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.ImageId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IMAGE_ID");

                entity.Property(e => e.InterviewDate)
                    .HasColumnType("DATE")
                    .HasColumnName("INTERVIEW_DATE");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Nid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.ProbablyJoiningDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PROBABLY_JOINING_DATE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.SignatureId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SIGNATURE_ID");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSE_NAME");
            });

            modelBuilder.Entity<TJobAppCircular>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_CIRCULAR");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.ActiveStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_STATUS");

                entity.Property(e => e.CircularEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CIRCULAR_END_DATE");

                entity.Property(e => e.CircularStartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CIRCULAR_START_DATE");

                entity.Property(e => e.CompanyDeptPost)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST");

                entity.Property(e => e.CompanyDeptPostActiveStatus)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST_ACTIVE_STATUS");

                entity.Property(e => e.CompanyDeptPostOpenDate)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST_OPEN_DATE");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.JobDescription)
                    .HasColumnType("CLOB")
                    .HasColumnName("JOB_DESCRIPTION");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.Post)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("POST");
            });

            modelBuilder.Entity<TJobAppCv>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_CV");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.Cv)
                    .HasColumnType("BLOB")
                    .HasColumnName("CV");

                entity.Property(e => e.CvName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CV_NAME");
            });

            modelBuilder.Entity<TJobAppExperience>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_EXPERIENCE");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantOid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.DefaultProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_PRODUCT");

                entity.Property(e => e.JobLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOB_LOCATION");

                entity.Property(e => e.Organization)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATION");

                entity.Property(e => e.Post)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST");

                entity.Property(e => e.ReportingTo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTING_TO");

                entity.Property(e => e.Salary)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.ApplicantO)
                    .WithMany(p => p.TJobAppExperiences)
                    .HasForeignKey(d => d.ApplicantOid)
                    .HasConstraintName("FK_T_JOB_APP_EXPERIENCE_APPLICANT_OID");
            });

            modelBuilder.Entity<TJobAppImage>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_IMAGE");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.Image)
                    .HasColumnType("BLOB")
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<TJobAppRegister>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_REGISTER");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFRESH_TOKEN");

                entity.Property(e => e.RefreshTokenExpireTime)
                    .HasColumnType("DATE")
                    .HasColumnName("REFRESH_TOKEN_EXPIRE_TIME");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TOKEN");
            });

            modelBuilder.Entity<TJobAppSignature>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("T_JOB_APP_SIGNATURE");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OID");

                entity.Property(e => e.Signature)
                    .HasColumnType("BLOB")
                    .HasColumnName("SIGNATURE");

                entity.Property(e => e.SignatureName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNATURE_NAME");
            });

            modelBuilder.Entity<TJobApplicantAcaQualification>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_ACA_QUALIFICATION_PK");

                entity.ToTable("T_JOB_APPLICANT_ACA_QUALIFICATION");

                entity.Property(e => e.Oid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.AcdmicqlfCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ACDMICQLF_CODE");

                entity.Property(e => e.ApplicantOid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.Board)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BOARD");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Degree)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE");

                entity.Property(e => e.Degreetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEGREETYPE");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Docname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCNAME");

                entity.Property(e => e.Institution)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTION");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.IslastDegree)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISLAST_DEGREE")
                    .IsFixedLength();

                entity.Property(e => e.Major)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAJOR");

                entity.Property(e => e.Passingyear)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PASSINGYEAR");

                entity.Property(e => e.Result)
                    .HasColumnType("NUMBER(4,2)")
                    .HasColumnName("RESULT");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobApplicantDocument>(entity =>
            {
                entity.HasKey(e => e.Documentid)
                    .HasName("T_JOB_APPLICANT_DOCUMENT_PK");

                entity.ToTable("T_JOB_APPLICANT_DOCUMENT");

                entity.Property(e => e.Documentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DOCUMENTID");

                entity.Property(e => e.Basepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BASEPATH");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Documentfullpath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTFULLPATH");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTNAME");

                entity.Property(e => e.Documentpath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTPATH");

                entity.Property(e => e.Documentsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTSIZE");

                entity.Property(e => e.Documenttype)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTTYPE");

                entity.Property(e => e.File)
                    .HasColumnType("BLOB")
                    .HasColumnName("FILE");

                entity.Property(e => e.Filename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FILENAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Originaldocname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINALDOCNAME");

                entity.Property(e => e.RefRowid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REF_ROWID");

                entity.Property(e => e.Referenceid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCEID");

                entity.Property(e => e.Tabletype)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TABLETYPE");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Virtualpath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VIRTUALPATH");
            });

            modelBuilder.Entity<TJobApplicantExperience>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_EXPERIENCE_PK");

                entity.ToTable("T_JOB_APPLICANT_EXPERIENCE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantOid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_TYPE");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Docname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCNAME");

                entity.Property(e => e.Experienceid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EXPERIENCEID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.IslastExperience)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISLAST_EXPERIENCE")
                    .IsFixedLength();

                entity.Property(e => e.Isrunning)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ISRUNNING");

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(3999)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DESCRIPTION");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.PriodFromDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRIOD_FROM_DATE");

                entity.Property(e => e.PriodToDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRIOD_TO_DATE");

                entity.Property(e => e.Salary)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SALARY");

                entity.Property(e => e.Totaldaycount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALDAYCOUNT");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobApplicantMainMaster>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_MAIN_MASTER_PK");

                entity.ToTable("T_JOB_APPLICANT_MAIN_MASTER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_CODE");

                entity.Property(e => e.Applydate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPLYDATE");

                entity.Property(e => e.Approveby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPROVEBY");

                entity.Property(e => e.Approvedate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPROVEDATE");

                entity.Property(e => e.Approvedecnote)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("APPROVEDECNOTE");

                entity.Property(e => e.Aprvdeclnby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APRVDECLNBY");

                entity.Property(e => e.Aprvdeclndate)
                    .HasColumnType("DATE")
                    .HasColumnName("APRVDECLNDATE");

                entity.Property(e => e.AprvrevNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("APRVREV_NOTE");

                entity.Property(e => e.AprvrevisionBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APRVREVISION_BY");

                entity.Property(e => e.AprvrevisionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APRVREVISION_DATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmpOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_OID");

                entity.Property(e => e.IsAprvrevision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_APRVREVISION")
                    .IsFixedLength();

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isapprove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISAPPROVE")
                    .IsFixedLength();

                entity.Property(e => e.Isaprvdecln)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISAPRVDECLN")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isjoining)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISJOINING")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isselected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSELECTED")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isverify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISVERIFY")
                    .IsFixedLength();

                entity.Property(e => e.Isverifydecline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISVERIFYDECLINE")
                    .IsFixedLength();

                entity.Property(e => e.Isviva)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISVIVA")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Iswritten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISWRITTEN")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Jobid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBID");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("DATE")
                    .HasColumnName("JOINING_DATE");

                entity.Property(e => e.OfficialMsg)
                    .HasMaxLength(3500)
                    .IsUnicode(false)
                    .HasColumnName("OFFICIAL_MSG");

                entity.Property(e => e.Profileoid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROFILEOID");

                entity.Property(e => e.SelectedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SELECTED_DATE");

                entity.Property(e => e.SetSalary)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SET_SALARY");

                entity.Property(e => e.Vdeclndate)
                    .HasColumnType("DATE")
                    .HasColumnName("VDECLNDATE");

                entity.Property(e => e.Vdeclvby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VDECLVBY");

                entity.Property(e => e.VerifyDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VERIFY_DATE");

                entity.Property(e => e.Verifyby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VERIFYBY");

                entity.Property(e => e.Verifydecnote)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("VERIFYDECNOTE");

                entity.Property(e => e.VivaDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VIVA_DATE");

                entity.Property(e => e.WrittenDate)
                    .HasColumnType("DATE")
                    .HasColumnName("WRITTEN_DATE");
            });

            modelBuilder.Entity<TJobApplicantMaster>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_MASTER_PK");

                entity.ToTable("T_JOB_APPLICANT_MASTER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_CODE");

                entity.Property(e => e.AppliedPost)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLIED_POST");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPLY_DATE");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BIRTH_PLACE");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BLOOD_GROUP");

                entity.Property(e => e.BnFatherName)
                    .HasMaxLength(60)
                    .HasColumnName("BN_FATHER_NAME");

                entity.Property(e => e.BnMotherName)
                    .HasMaxLength(60)
                    .HasColumnName("BN_MOTHER_NAME");

                entity.Property(e => e.BnName)
                    .HasMaxLength(60)
                    .HasColumnName("BN_NAME");

                entity.Property(e => e.BnSpouseName)
                    .HasMaxLength(60)
                    .HasColumnName("BN_SPOUSE_NAME");

                entity.Property(e => e.CompanyDeptPostOpenDate)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DEPT_POST_OPEN_DATE");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.CvPath)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CV_PATH");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Department)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmpOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_OID");

                entity.Property(e => e.ExpectedSelery)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPECTED_SELERY");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.GrandtotalDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GRANDTOTAL_DAYS");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isconfirm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISCONFIRM");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Isjoining)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISJOINING")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isrelative)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISRELATIVE")
                    .IsFixedLength();

                entity.Property(e => e.Isview)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ISVIEW");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.Jobid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("JOBID");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("DATE")
                    .HasColumnName("JOINING_DATE");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS");

                entity.Property(e => e.Message)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Nid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.NidBackPath)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NID_BACK_PATH");

                entity.Property(e => e.NidPath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NID_PATH");

                entity.Property(e => e.OfficialMsg)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("OFFICIAL_MSG");

                entity.Property(e => e.ParAddDetail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD_DETAIL");

                entity.Property(e => e.ParAddDistrict)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD_DISTRICT");

                entity.Property(e => e.ParAddDivision)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD_DIVISION");

                entity.Property(e => e.ParAddPostOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD_POST_OFFICE");

                entity.Property(e => e.ParAddThana)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD_THANA");

                entity.Property(e => e.ParAddVillage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAR_ADD_VILLAGE");

                entity.Property(e => e.PerAddDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PER_ADD_DISTRICT");

                entity.Property(e => e.Post)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST");

                entity.Property(e => e.PreAddDetail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PRE_ADD_DETAIL");

                entity.Property(e => e.PreAddDivision)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRE_ADD_DIVISION");

                entity.Property(e => e.PreAddPostOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRE_ADD_POST_OFFICE");

                entity.Property(e => e.PreAddThana)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRE_ADD_THANA");

                entity.Property(e => e.PreAddVillage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRE_ADD_VILLAGE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.SetSalary)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SET_SALARY");

                entity.Property(e => e.SignaturePath)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("SIGNATURE_PATH");

                entity.Property(e => e.SourceFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_FROM");

                entity.Property(e => e.Specifyrelative)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SPECIFYRELATIVE");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSE_NAME");

                entity.Property(e => e.Tin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TIN");

                entity.Property(e => e.TinPath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIN_PATH");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobApplicantProfCertificate>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_PROF_CERTIFICATE_PK");

                entity.ToTable("T_JOB_APPLICANT_PROF_CERTIFICATE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.AchievmentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ACHIEVMENT_DATE");

                entity.Property(e => e.ApplicantOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.Certificatecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CERTIFICATECODE");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_NAME");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Creation)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Deletion)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETION");

                entity.Property(e => e.Docname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCNAME");

                entity.Property(e => e.Institution)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTION");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.StartDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Updation)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATION");
            });

            modelBuilder.Entity<TJobApplicantReference>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_REFERENCE_PK");

                entity.ToTable("T_JOB_APPLICANT_REFERENCE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.ApplicantOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Creation)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Deletion)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETION");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Organization)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATION");

                entity.Property(e => e.Referencecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCECODE");

                entity.Property(e => e.Relation)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RELATION");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Updation)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATION");
            });

            modelBuilder.Entity<TJobApplicantTraining>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_APPLICANT_TRAINING_PK");

                entity.ToTable("T_JOB_APPLICANT_TRAINING");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantOid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_OID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Creation)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Deletion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETION");

                entity.Property(e => e.Docname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCNAME");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Institution)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTION");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.TrainingName)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("TRAINING_NAME");

                entity.Property(e => e.Trainingcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRAININGCODE");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Updation)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATION");
            });

            modelBuilder.Entity<TJobCmnmenu>(entity =>
            {
                entity.HasKey(e => e.Menuid)
                    .HasName("T_JOB_CMNMENU_PK");

                entity.ToTable("T_JOB_CMNMENU");

                entity.Property(e => e.Menuid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Issubparent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSUBPARENT")
                    .IsFixedLength();

                entity.Property(e => e.Menuicon)
                    .HasMaxLength(100)
                    .HasColumnName("MENUICON");

                entity.Property(e => e.Menuname)
                    .HasMaxLength(100)
                    .HasColumnName("MENUNAME");

                entity.Property(e => e.Menupath)
                    .HasMaxLength(300)
                    .HasColumnName("MENUPATH");

                entity.Property(e => e.Menushortname)
                    .HasMaxLength(100)
                    .HasColumnName("MENUSHORTNAME");

                entity.Property(e => e.Menutypeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUTYPEID");

                entity.Property(e => e.Moduleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MODULEID");

                entity.Property(e => e.Parentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARENTID");

                entity.Property(e => e.Sequence)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SEQUENCE");

                entity.Property(e => e.Subparentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SUBPARENTID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_JOB_EMPLOYEE");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1\n   ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobRecruitmentApplicantExam>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_RECRUITMENT_EXAM_COMMITTEE_PK");

                entity.ToTable("T_JOB_RECRUITMENT_APPLICANT_EXAM");

                entity.Property(e => e.Oid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.ExamDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXAM_DATE");

                entity.Property(e => e.ExamMarks)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("EXAM_MARKS");

                entity.Property(e => e.Examinar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXAMINAR");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EXAMTYPE");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Isattend)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISATTEND");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .IsFixedLength();

                entity.Property(e => e.Isselected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSELECTED")
                    .IsFixedLength();

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.ReqAprvOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REQ_APRV_OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobRecruitmentApprovalFlow>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_RECRUITMENT_APPROVAL_FLOW_PK");

                entity.ToTable("T_JOB_RECRUITMENT_APPROVAL_FLOW");

                entity.Property(e => e.Oid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OID");

                entity.Property(e => e.ApplicantId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANT_ID");

                entity.Property(e => e.FapproveBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FAPPROVE_BY");

                entity.Property(e => e.FapproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("FAPPROVE_DATE");

                entity.Property(e => e.FapproveNote)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("FAPPROVE_NOTE");

                entity.Property(e => e.HobusinessBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HOBUSINESS_BY");

                entity.Property(e => e.HobusinessDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HOBUSINESS_DATE");

                entity.Property(e => e.HobusinessNote)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("HOBUSINESS_NOTE");

                entity.Property(e => e.HounitBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HOUNIT_BY");

                entity.Property(e => e.HounitDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HOUNIT_DATE");

                entity.Property(e => e.HounitNote)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("HOUNIT_NOTE");

                entity.Property(e => e.HrbpBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HRBP_BY");

                entity.Property(e => e.HrbpDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HRBP_DATE");

                entity.Property(e => e.HrbpNote)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("HRBP_NOTE");

                entity.Property(e => e.IsFapprove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_FAPPROVE")
                    .IsFixedLength();

                entity.Property(e => e.Ishobusiness)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISHOBUSINESS")
                    .IsFixedLength();

                entity.Property(e => e.Ishounit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISHOUNIT")
                    .IsFixedLength();

                entity.Property(e => e.Ishrbp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISHRBP")
                    .IsFixedLength();

                entity.Property(e => e.Isprepared)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISPREPARED");

                entity.Property(e => e.PreparedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PREPARED_BY");

                entity.Property(e => e.PreparedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PREPARED_DATE");

                entity.Property(e => e.PreparedNote)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("PREPARED_NOTE");

                entity.Property(e => e.RecruitmentCklstOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RECRUITMENT_CKLST_OID");
            });

            modelBuilder.Entity<TJobRecruitmentApprovalMaster>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_RECRUITMENT_APPROVAL_MASTER_PK");

                entity.ToTable("T_JOB_RECRUITMENT_APPROVAL_MASTER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Applicantoid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTOID");

                entity.Property(e => e.BonusType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BONUS_TYPE");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEDBY");

                entity.Property(e => e.Createdpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEDPC");

                entity.Property(e => e.Creation)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Deletion)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETION");

                entity.Property(e => e.Designation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.FinalApprove)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FINAL_APPROVE");

                entity.Property(e => e.HeadofBusinessUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HEADOF_BUSINESS_UNIT");

                entity.Property(e => e.HeadofUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HEADOF_UNIT");

                entity.Property(e => e.Hrbp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HRBP");

                entity.Property(e => e.IsFinalApprove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_FINAL_APPROVE")
                    .IsFixedLength();

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdormitory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDORMITORY")
                    .IsFixedLength();

                entity.Property(e => e.Isincrement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISINCREMENT")
                    .IsFixedLength();

                entity.Property(e => e.Isinsurance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISINSURANCE")
                    .IsFixedLength();

                entity.Property(e => e.Ismedical)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISMEDICAL")
                    .IsFixedLength();

                entity.Property(e => e.Ispf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISPF")
                    .IsFixedLength();

                entity.Property(e => e.Issim)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSIM")
                    .IsFixedLength();

                entity.Property(e => e.Istransport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISTRANSPORT")
                    .IsFixedLength();

                entity.Property(e => e.JobRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOB_ROLE");

                entity.Property(e => e.JobType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TYPE");

                entity.Property(e => e.Jobid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JOBID");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("DATE")
                    .HasColumnName("JOINING_DATE");

                entity.Property(e => e.Linemanager)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LINEMANAGER");

                entity.Property(e => e.PreparedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PREPARED_BY");

                entity.Property(e => e.Profileoid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROFILEOID");

                entity.Property(e => e.RequsitionOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REQUSITION_OID");

                entity.Property(e => e.Salary)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SALARY");

                entity.Property(e => e.SalaryGrade)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SALARY_GRADE");

                entity.Property(e => e.SalaryReviewer)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SALARY_REVIEWER");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEDBY");

                entity.Property(e => e.Updatedpc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEDPC");

                entity.Property(e => e.Updation)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATION");
            });

            modelBuilder.Entity<TJobRecruitmentExaminer>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_RECRUITMENT_EXAMINER_PK");

                entity.ToTable("T_JOB_RECRUITMENT_EXAMINER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.AempOid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEMP_OID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TJobRegister>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_JOB_REGISTER_PK");

                entity.ToTable("T_JOB_REGISTER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Department)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Empid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPID");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE");

                entity.Property(e => e.Isreg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISREG");

                entity.Property(e => e.Mobilenumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MOBILENUMBER");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<TRoleSetup>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("T_ROLE_SETUP_PK");

                entity.ToTable("T_ROLE_SETUP");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETELPC");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TSysUser>(entity =>
            {
                entity.HasKey(e => e.Sysid)
                    .HasName("T_JOB_SYS_USER_PK");

                entity.ToTable("T_SYS_USER");

                entity.Property(e => e.Sysid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SYSID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Expireotp)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIREOTP");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Issys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSYS")
                    .HasDefaultValueSql("0\n   ")
                    .IsFixedLength();

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER");

                entity.Property(e => e.Otp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OTP");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<TTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_TEST");

                entity.Property(e => e.Oid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.SprodBnam)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SPROD_BNAM");

                entity.Property(e => e.SprodName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SPROD_NAME");

                entity.Property(e => e.SprodOpdt)
                    .HasColumnType("DATE")
                    .HasColumnName("SPROD_OPDT");

                entity.Property(e => e.SprodText)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SPROD_TEXT");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_USER_PK");

                entity.ToTable("T_USER");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_ID");

                entity.Property(e => e.Edat)
                    .HasColumnType("DATE")
                    .HasColumnName("EDAT")
                    .HasDefaultValueSql("sysdate");

                entity.Property(e => e.Euser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EUSER")
                    .HasDefaultValueSql("user");

                entity.Property(e => e.Idat)
                    .HasColumnType("DATE")
                    .HasColumnName("IDAT")
                    .HasDefaultValueSql("sysdate");

                entity.Property(e => e.Iuser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IUSER")
                    .HasDefaultValueSql("user");

                entity.Property(e => e.UserBkdt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_BKDT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_EMAIL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserPass)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USER_PASS");

                entity.Property(e => e.UserPrnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_PRNT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UserRexp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_REXP")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UserRpnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_RPNT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UserSname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_SNAME");

                entity.Property(e => e.UserSpcl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_SPCL")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_STAT")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UserText)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USER_TEXT");

                entity.Property(e => e.UserType)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");

                entity.Property(e => e.UserWeb)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USER_WEB")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TUserMenu>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_USER_MENU_PK");

                entity.ToTable("T_USER_MENU");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.DeviceIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_IP");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_USER");

                entity.Property(e => e.Edat)
                    .HasColumnType("DATE")
                    .HasColumnName("EDAT")
                    .HasDefaultValueSql("sysdate");

                entity.Property(e => e.EditDeviceIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_DEVICE_IP");

                entity.Property(e => e.EditDeviceName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_DEVICE_NAME");

                entity.Property(e => e.EditDeviceUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_DEVICE_USER");

                entity.Property(e => e.Euser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EUSER")
                    .HasDefaultValueSql("user");

                entity.Property(e => e.Idat)
                    .HasColumnType("DATE")
                    .HasColumnName("IDAT")
                    .HasDefaultValueSql("sysdate");

                entity.Property(e => e.Iuser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IUSER")
                    .HasDefaultValueSql("user");

                entity.Property(e => e.UsermenuActv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USERMENU_ACTV");

                entity.Property(e => e.UsermenuMnud)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERMENU_MNUD");

                entity.Property(e => e.UsermenuUser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERMENU_USER");
            });

            modelBuilder.Entity<TUserRole>(entity =>
            {
                entity.HasKey(e => e.Userroleid)
                    .HasName("T_USER_ROLE_PK");

                entity.ToTable("T_USER_ROLE");

                entity.Property(e => e.Userroleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERROLEID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1\n   ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");
            });

            modelBuilder.HasSequence("HR_JOB_APP");

            modelBuilder.HasSequence("SEQ_ADDESS_OID");

            modelBuilder.HasSequence("SEQ_ADDRESSES_OID");

            modelBuilder.HasSequence("SEQ_APPLICANTS_OID");

            modelBuilder.HasSequence("SEQ_EXPERIENCE_OID");

            modelBuilder.HasSequence("SEQ_EXPERIENCES_OID");

            modelBuilder.HasSequence("SEQ_OID");

            modelBuilder.HasSequence("SEQ_QULIFICATION_OID");

            modelBuilder.HasSequence("SEQ_QULIFICATIONS_OID");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
