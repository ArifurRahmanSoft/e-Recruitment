using DataFactories.BaseFactory;
using DataFactories.Infrastructure.common.processflow;
using DataFactory.Infrastructure.services.messageservice;
//using DataModel.EntityModels.OraModel;
using DataModel.JobEntityModel.JobOraModelTest;
using DataModel.ViewModels;
using DataModel.ViewModels.ERPViewModel.Business;
using DataModel.ViewModels.ERPViewModel.Common;
using DataUtility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static DataUtility.StaticInfos;

namespace DataFactories.Infrastructure.business.candidateinfo
{
    public class CandidateInfoMgt
    {
        #region Variable declaration & initialization
        ModelContext _ctxOra = null;
        private vmSrvcReqMail _jMail = new vmSrvcReqMail();
        private emailmessageMgt _emanager = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        OracleCommand ocmd = null;
        Hashtable ht = null; OracleParameter[] oprm = null;
        #endregion

        #region Constructor
        public CandidateInfoMgt(IConfiguration iConfig, string WebRootPath)
        {
           // _jMail.MailTo = iConfig.GetSection("StaticMail").GetSection("SoftSupport").Value;
            //_jMail.NameTo = iConfig.GetSection("StaticMail").GetSection("SoftSupportName").Value;
            _emanager = new emailmessageMgt(iConfig, WebRootPath);
        }
        #endregion Constructor




        public async Task<object> GetWithPagination(vmCmnParameter param) //vmCmnParameters cmnParam vmCmnParameter
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listJobPost = string.Empty;
            param.Role = Regex.Replace(param.Role ?? "", @"\s*,\s*", " ");
            object result = null;
            try
            {
                        ht = new Hashtable
                        {
                            { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                              { "JobTitle", (1, OracleDbType.Varchar2, param.JobTitle)},
                              { "Company", (2, OracleDbType.Varchar2, param.Company)},
                             { "Department", (3, OracleDbType.Varchar2, param.Department)},
                             { "Post", (4, OracleDbType.Varchar2, param.Post)},
                             { "Role", (5, OracleDbType.Varchar2, param.Role)},
                             { "UserID", (6, OracleDbType.Varchar2, param.UserID)},
                             
                             // { "StartDate", (4, OracleDbType.Date, param.StartDate)},
                            // { "EndDate", (5, OracleDbType.Date, param.EndDate)}
                   



                        };
          


                listJobPost = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_candidateInfoByPage, ht, "gresult", StaticInfos.conStringOracle.ToString());
               

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listJobPost
            };
        }


        public async Task<object> GetApplicationLstWithPagination(vmCmnParameter param) //vmCmnParameters cmnParam vmCmnParameter
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listJobPost = string.Empty;
            param.Role = Regex.Replace(param.Role ?? "", @"\s*,\s*", " ");
            int psize = param.pageSize == null ? 0 : Convert.ToInt32(param.pageSize);
            string JobTitle = param.JobTitle == null ? null : param.JobTitle;
            string Post = param.Post == null ? null : param.Post;
            string approvalProc = param.approvalProcess == null ? null : param.approvalProcess;

            object result = null;
            try
            {
                ht = new Hashtable
                        {
                              { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                              { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                              { "PageSize", (2, psize) },
                              { "SearchVal", (3, param.SearchVal.Trim().ToLower()) },
                              { "LoggedUserId", (4, param.LoggedUserId) },
                              { "JobTitle", (5, OracleDbType.Varchar2, param.JobTitle)},
                              { "Role", (6, OracleDbType.Varchar2, param.Role)},
                              { "Post", (7, OracleDbType.Varchar2, param.Post)},
                              //{ "fromExperience", (8, OracleDbType.Varchar2, param.fromNumber)},
                              { "fromExperience", (8, Convert.ToInt32(param.fromNumber))},
                              { "toExperience", (9, Convert.ToInt32(param.toNumber))},
                              { "Status", (10, Convert.ToString(param.Status))},
                              { "approvalProc", (11, Convert.ToString(param.approvalProcess))},

                        };

                listJobPost = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_ApplicationListByPage, ht, StaticInfos.conStringOracle.ToString());


            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listJobPost
            };
        }

        public async Task<object> GetProfileLstWithPagination(vmCmnParameter param) //vmCmnParameters cmnParam vmCmnParameter
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listProfile = string.Empty;
            param.Role = Regex.Replace(param.Role ?? "", @"\s*,\s*", " ");
            int psize = param.pageSize == null ? 0 : Convert.ToInt32(param.pageSize);
            object result = null;
            try
            {
                ht = new Hashtable
                        {
                              { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                              { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                              { "PageSize", (2, psize) },
                              { "SearchVal", (3, param.SearchVal.Trim().ToLower()) },
                              { "LoggedUserId", (4, param.LoggedUserId) },
                              { "Role", (5, OracleDbType.Varchar2, param.Role)},
                             
                           
                        };
                //listJobPost = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_ApplicationListByPage, ht, "gresult", StaticInfos.conStringOracle.ToString());
                listProfile = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_ApplicantProfileListByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listProfile
            };
        }



        public async Task<object> getallapplication(vmCmnParameter param) //vmCmnParameters cmnParam vmCmnParameter
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listApplicant = string.Empty;
            param.Role = Regex.Replace(param.Role ?? "", @"\s*,\s*", " ");
            object result = null;
            try
            {
                ht = new Hashtable
                        {
                            { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                              { "JobTitle", (1, OracleDbType.Varchar2, param.JobTitle)},
                              { "Company", (2, OracleDbType.Varchar2, param.Company)},
                             { "Department", (3, OracleDbType.Varchar2, param.Department)},
                             { "Post", (4, OracleDbType.Varchar2, param.Post)},
                             { "Role", (5, OracleDbType.Varchar2, param.Role)},
                             { "UserID", (6, OracleDbType.Varchar2, param.UserID)},
                             
                             // { "StartDate", (4, OracleDbType.Date, param.StartDate)},
                            // { "EndDate", (5, OracleDbType.Date, param.EndDate)}
                   



                        };



                listApplicant = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_ApplicantListByParam, ht, "gresult", StaticInfos.conStringOracle.ToString());


            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listApplicant
            };
        }
        

        public async Task<object> GetByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string jobPostMaster = string.Empty, jobSkill = string.Empty, jobBenefit = string.Empty, jobRequirement = string.Empty, jobOtherRequirement = string.Empty, jobResponsibility = string.Empty; 
            try
            {
               
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gJobPostId", (1, OracleDbType.Varchar2, cparam.strId)}//
                };
                //gQuotationId
                jobPostMaster = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobPostMasterById, ht, "gresult", StaticInfos.conStringOracle.ToString());
              if (!string.IsNullOrEmpty(jobPostMaster) )

                {
                    jobSkill = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobPostSkillById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobBenefit = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobBenifitById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobRequirement = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobRequirementById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobOtherRequirement = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobOtherRequirementById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobResponsibility = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobResponsibilityById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                }





            


            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                jobPostMaster,
                jobSkill,
                jobBenefit,
                jobRequirement,
                jobOtherRequirement,
                jobResponsibility

            };
        }


        //FOR TEST PURPOSE START FROM HERE 
        public async Task<DataTable> GetByIDS(vmCmnParameter param)//this is test purpuse
        {
            DataTable dt = new DataTable();

            using (var conn = new OracleConnection(StaticInfos.conStringOracle.ToString()))
            {
                string sql = "SELECT OID, JOB_TITLE, COMPANY,DEPARTMENT,POST FROM T_ADMIN_JOB_POST_MASTER WHERE OID = :pID";

                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("pID", OracleDbType.Varchar2).Value = param.strId;

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }


        //FOR TEST PURPOSE END HERE




        public async Task<object> getNotificationById(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string notificationList = string.Empty;
            try
            {

                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gUserId", (1, OracleDbType.Varchar2, cparam.LoggedUserId)}
                };
                //gQuotationId
                notificationList = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_NotificationById, ht, "gresult", StaticInfos.conStringOracle.ToString());
             


            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                notificationList,
           

            };
        }













        /*  public async Task<object> MailingProcess(vmEmailDetailsModel cmnparam)
          {
              OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
              dynamic result = null, resstate = false;
              string ccEmail = string.Empty, srvcInfo = string.Empty, mailQuery = string.Empty, fromMail = string.Empty, fromEmail = string.Empty, toEmail = string.Empty, srvcQuery = string.Empty, fromName = string.Empty;
              DateTime parsedDate = DateTime.Parse(cmnparam.examDate);
              string examDate = parsedDate.ToString("dd-MM-yyyy");
              srvcQuery = "hellp , wo";
              srvcInfo = await OraGeneric_vmCmnParameter.GetByQueryJsonString(srvcQuery, StaticInfos.conStringOracle.ToString());
              srvcInfo = srvcInfo.Replace("[", "").Replace("]", "");
              vmServiceRequest vsr = JsonConvert.DeserializeObject<vmServiceRequest>(srvcInfo.ToString());
              fromName = cmnparam.name;
              mailQuery = "";

              fromEmail = "arif.cgit@gmail.com";


              _jMail.MailCC = string.Empty;
              _jMail.MailTo = "arif.bd08060@gmail.com";// cmnparam.toEmail;// "arif.bd08060@gmail.com";
              _jMail.Subject = "Offer Latter";
              _jMail.Title = "Career City Group";//fixed
              _jMail.jobTitle = cmnparam.jobTitle;
              _jMail.Company = cmnparam.CompanyName;
              _jMail.department = cmnparam.department;
              _jMail.post = cmnparam.post;
              _jMail.NameTo = cmnparam.name;
              _jMail.examDate = examDate; 
              _jMail.examHour = cmnparam.examHour; 


              _jMail.NameFrom = "fromName";
              _jMail.MailFrom = fromEmail;

              _jMail.Message1 = "Please Update Requested Service status is in below:";
              _jMail.Status = "New";
              _jMail.CreateBy = cmnparam.loggedUserId;
              _jMail.CreateOn = "vsr.CREATEON";
              _jMail.ResponseBy = "";
              _jMail.ResponseOn = "";

              result = await _emanager.ServiceRequestMail(vsr, _jMail);
              if (result.resstate == true)
              {
                  result = await UpdateCandidateByMailType(cmnparam, parsedDate);
              }

              return result;
          }
 */

        public async Task<object> MailingProcess(string cmnparams)
        {
            List<vmEmailDetailsModel> paramList = JsonConvert.DeserializeObject<List<vmEmailDetailsModel>>(cmnparams);
          
            dynamic result = null, resstate = false;
            string ccEmail = string.Empty, srvcInfo = string.Empty, mailQuery = string.Empty, fromMail = string.Empty, fromEmail = string.Empty,
                toEmail = string.Empty, srvcQuery = string.Empty, fromName = string.Empty;


            foreach (var cmnparam in paramList)
            {
                DateTime parsedDate = DateTime.Parse(cmnparam.examDate);
                string examDate = parsedDate.ToString("dd-MM-yyyy");
                srvcQuery = "hellp , wo";
                srvcInfo = "";//await OraGeneric_vmCmnParameter.GetByQueryJsonString(srvcQuery, StaticInfos.conStringOracle.ToString());
                srvcInfo = srvcInfo.Replace("[", "").Replace("]", "");
                vmServiceRequest vsr = JsonConvert.DeserializeObject<vmServiceRequest>(srvcInfo.ToString());
                fromName = cmnparam.name;
                mailQuery = "";

                fromEmail = "career@citygroupbd.com";
               


                _jMail.MailCC = string.Empty;
                //_jMail.MailTo = "arifur.rahman@citygroupbd.com";//"arif.bd08060@gmail.com";// cmnparam.toEmail;// cmnparam.toEmail;// ;
                _jMail.MailTo = cmnparam.toEmail;// "arif.bd08060@gmail.com";
                _jMail.Subject = "Offer Latter"; //cmnparam.mailType;// 
                _jMail.Title =  "Career City Group";//fixed
                _jMail.jobTitle = cmnparam.jobTitle;
                _jMail.Company = cmnparam.CompanyName;
                _jMail.department = cmnparam.department;
                _jMail.post = cmnparam.post;
                _jMail.NameTo = cmnparam.name;
                _jMail.examDate = examDate;
                _jMail.examHour = cmnparam.examHour;


                _jMail.NameFrom = "fromName";
                _jMail.MailFrom = fromEmail;

                _jMail.Message1 = "Please Update Requested Service status is in below:";
                _jMail.Status = "New";
                _jMail.CreateBy = cmnparam.loggedUserId;
                _jMail.CreateOn = "vsr.CREATEON";
                _jMail.ResponseBy = "";
                _jMail.ResponseOn = "";

                result = await _emanager.ServiceRequestMail(vsr, _jMail);
                if (result.resstate == true)
                {
                    result = await UpdateCandidateByMailType(cmnparam, parsedDate);
                }
            }


             

            return result;
        }


        public async Task<object> UpdateCandidateByMailType(vmEmailDetailsModel cmnparam, DateTime Examdate)
        {
            bool resstate = false;
            string message = string.Empty;
            string hrMessage = $"Dear {cmnparam.name}, Your exam will be held on {cmnparam.examDate} at {cmnparam.examHour}. More details check your mail.";
            string hrMessageOffer = $"Dear {cmnparam.name}, your joining date before {Examdate}. More details check your mail.";


            try
            {
                using (_ctxOra = new ModelContext())
                {
                    var user = await _ctxOra.TJobApplicantMainMasters
                        .FirstOrDefaultAsync(u => u.Oid == cmnparam.applicantId);

                    if (user == null)
                        return new { message = "User not found.", resstate = false };

                    if (cmnparam.mailType == "OfferLater")
                    {
                        user.Isselected = "1";
                        user.SelectedDate = Examdate;
                        user.OfficialMsg = hrMessageOffer;
                    }
                     if (cmnparam.mailType == "written")
                    {
                        user.Iswritten = "1";
                        user.WrittenDate = Examdate;
                        user.OfficialMsg = hrMessage;
                    }
                     if (cmnparam.mailType == "viva")
                    {
                        user.Isviva = "1";
                        user.VivaDate = Examdate;
                        user.OfficialMsg = hrMessage;
                    }
                     if (cmnparam.mailType == "writtenViva")
                    {
                        user.Iswritten = "1";
                        user.Isviva = "1";
                        user.WrittenDate = Examdate;
                        user.VivaDate = Examdate;
                        user.OfficialMsg = hrMessage;
                    }

                    await _ctxOra.SaveChangesAsync();

                    resstate = true;
                    message = "Mail Sent successful.";

                    return new { message, resstate };
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                message = MessageConstants.MailWarning;
                resstate = MessageConstants.ErrorState;
                return new { message, resstate };
            }
        }






        public async Task<object> GetExaminarListByPages(vmCmnParameter param) //vmCmnParameters cmnParam vmCmnParameter
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listExaminar = string.Empty;
            int psize = param.pageSize == null ? 0 : Convert.ToInt32(param.pageSize);
            object result = null;
            try
            {
                ht = new Hashtable
                        {
                              { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                              { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                              { "PageSize", (2, psize) },
                              { "SearchVal", (3, " ") },
                              { "LoggedUserId", (4, param.LoggedUserId) },
                              


                        };
                //listJobPost = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_ApplicationListByPage, ht, "gresult", StaticInfos.conStringOracle.ToString());
                listExaminar = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_ExaminarByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listExaminar
            };
        }










        public async Task<object> GetDrpdownAllExaminar() 
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listAllExaminar = string.Empty;;
            object result = null;
            try
            {
                ht = new Hashtable
                        {
                              { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) }         
                        }; 
                listAllExaminar = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_AllExaminarDrpdwn, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listAllExaminar
            };
        }



        public async Task<object> GetDrpdownAllEmployee()
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listAllEmployee = string.Empty; ;
            object result = null;
            try
            {
                ht = new Hashtable
                        {
                              { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) }
                        };
                listAllEmployee = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_AllEmployeeDrpdwn, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listAllEmployee
            };
        }





























    }
}