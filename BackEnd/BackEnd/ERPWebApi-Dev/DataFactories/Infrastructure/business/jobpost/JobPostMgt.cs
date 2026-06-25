using DataFactories.BaseFactory;
using DataFactories.Infrastructure.common.processflow;
using DataModel.EntityModels.OraModel;
using DataModel.ViewModels;
using DataModel.ViewModels.ERPViewModel.Business;
using DataModel.ViewModels.ERPViewModel.Common;
using DataUtility;
using Microsoft.EntityFrameworkCore;
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

namespace DataFactories.Infrastructure.business.jobpost
{
    public class JobPostMgt
    {
        #region Variable declaration & initialization
        ModelContext _ctxOra = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        OracleCommand ocmd = null;
        Hashtable ht = null; OracleParameter[] oprm = null;
        #endregion
   


    public async Task<object> SaveUpdate(string _mJsonData, string _sklJsonData,  string _resJsonData, string _reqJsonData,
    string _expJsonData, string _othReqJsonData, string _bnfJsonData, vmCmnParameter param )
    {
        object referenceId = 0; string message = string.Empty; bool resstate = false;
        OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
        string result = string.Empty, mstrRes = string.Empty;
        try
        {
            
            ocmd = new OracleCommand();
            ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
            ocmd.Parameters.Add("JsonData_Mstr", OracleDbType.Clob).Value = _mJsonData;
            ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
            ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

            mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostMstr, ocmd, "mresult", StaticInfos.conStringOracle.ToString());

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                ocmd.Parameters.Add("JsonData_Skl", OracleDbType.Clob).Value = _sklJsonData;
              result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostSkill, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
            }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Res", OracleDbType.Clob).Value = _resJsonData;
                    result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostResp, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Requirement", OracleDbType.Clob).Value = _reqJsonData;
                    result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostReq, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Experience", OracleDbType.Clob).Value = _expJsonData;
                    result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostExp, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_OtherRequirement", OracleDbType.Clob).Value = _othReqJsonData;
                    result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostOtReq, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Benifit", OracleDbType.Clob).Value = _bnfJsonData;
                    result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_JobPostBenefit, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(result) && result != "0" && result != "null")
            {

                 



                  /*  if (string.IsNullOrEmpty(param.strId))
                    {
                        var PrcsFlowMgt = new ProcessFlowMgt();
                        param.strId = result;
                        await PrcsFlowMgt.ProceedFirstForwardToNext(param);
                    }*/

                    message = MessageConstants.Saved;
                resstate = MessageConstants.SuccessState;
            }
            else
            {
                message = MessageConstants.SavedWarning;
            }
        }
        catch (Exception ex)
        {
            Logs.Bug(ex);
        }
        return new
        {
            message,
            resstate
        };
    }///BusinessTypeSaveUpdate


        public async Task<object> GetWithList(vmCmnParameter param) //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listJobPost = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                
                };


                listJobPost = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_JobPostByList, ht, StaticInfos.conStringOracle.ToString());
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


   /*     public async Task<object> GetLocationList() //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listLocation = string.Empty; string listLocations = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },

                };


                listLocation =  await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_LocationList, ht, StaticInfos.conStringOracle.ToString());
               
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listLocation = JsonConvert.DeserializeObject(listLocation)
              
            };
        }*/



        public async Task<object> GetLocationList()
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listLocation = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) }
                
                };
                listLocation = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_LocationList, ht, "gresult", StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listLocation,
            };
        }


        public async Task<object> GetWithPagination(vmCmnParameter param) //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listJobPost = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "SearchVal", (3, param.SearchVal.Trim().ToLower()) },
                    { "LoggedUserId", (4, param.LoggedUserId) }
                };
               

                listJobPost = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_JobPostByPage, ht, StaticInfos.conStringOracle.ToString());
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


       


        public async Task<object> GetByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string jobPostMaster = string.Empty, jobSkill = string.Empty, jobBenefit = string.Empty, jobRequirement = string.Empty, jobOtherRequirement = string.Empty, jobResponsibility = string.Empty;
            string jobExperience = string.Empty;
            try
            {
               
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gJobPostId", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                jobPostMaster = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobPostMasterById, ht, "gresult", StaticInfos.conStringOracle.ToString());
              if (!string.IsNullOrEmpty(jobPostMaster) )

                {
                    jobSkill = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobPostSkillById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobBenefit = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobBenifitById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobRequirement = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobRequirementById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                    jobExperience = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_JobExperienceById, ht, "gresult", StaticInfos.conStringOracle.ToString());
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
                jobExperience,
                jobOtherRequirement,
                jobResponsibility

            };
        }



        //GET REQUSITION BY PAGES

        public async Task<object> GetReqByPage(vmCmnParameter param) //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listJobRequsition = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "SearchVal", (3, param.SearchVal.Trim().ToLower()) },
                    { "LoggedUserId", (4, param.LoggedUserId) }
                };
                listJobRequsition = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_RequisitionByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listJobRequsition
            };
        }


        public async Task<object> GetReqByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string jobRequisition = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gRequsitaionId", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                jobRequisition = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Get_RequisitionById, ht, "gresult", StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                jobRequisition,
            };
        }


        public async Task<object> BusinessTypeSaveUpdate(string _mJsonData,  vmCmnParameter param)
        {
            object referenceId = 0; string message = string.Empty; bool resstate = false;
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty, mstrRes = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData_Mstr", OracleDbType.Clob).Value = _mJsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_Business, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(mstrRes) || mstrRes != "0" || mstrRes != "null")
                {
                    message = MessageConstants.Saved;
                    resstate = MessageConstants.SuccessState;
                }
                else
                {
                    message = MessageConstants.SavedWarning;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                message,
                resstate
            };
        }

        public async Task<object> BusinessGetWithPagination(vmCmnParameter param) //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listBusinessType = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "SearchVal", (3, param.SearchVal.Trim().ToLower()) },
                    { "LoggedUserId", (4, param.LoggedUserId) }
                };

                listBusinessType = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_BusinessByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listBusinessType
            };
        }


        


   public async Task<object> BusinessGetByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string businessMaster = string.Empty;
            try
            {

                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gBusinessId", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                businessMaster = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Get_BusinessById, ht, "gresult", StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                businessMaster
            };
        }



   

        public async Task<object> getDistinctCompanyJob() //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listCompany = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                };

                listCompany = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGetJobPostCompany, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listCompany
            };
        }


        public async Task<object> getDistinctDepartmentJob() //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listDepartment = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                };

                listDepartment = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGetJobPostDepartment, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listDepartment
            };
        }


        public async Task<object> getDistinctDesignationJob() //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listDesignation = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "qresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                };

                listDesignation = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGetJobPostDesignation, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listDesignation
            };
        }


































    }
}