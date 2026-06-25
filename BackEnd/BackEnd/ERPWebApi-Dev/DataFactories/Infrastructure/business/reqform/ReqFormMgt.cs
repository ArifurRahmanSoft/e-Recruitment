using DataFactories.BaseFactory;
using DataFactories.Infrastructure.common.processflow;
using DataModel.JobEntityModel.JobOraModelTest;

//using DataModel.EntityModels.OraModel;
using DataModel.ViewModels;
using DataModel.ViewModels.ERPViewModel.Business;
using DataModel.ViewModels.ERPViewModel.Common;
using DataUtility;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataFactories.Infrastructure.business.reqform
{
    public class ReqFormMgt
    {
        #region Variable declaration & initialization
        ModelContext _ctxOra = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        OracleCommand ocmd = null;
        Hashtable ht = null; OracleParameter[] oprm = null; Hashtable gt = null;
        #endregion



        public async Task<object> GetUserDetailsByID(vmCmnParameter cparam)//GetApplicantProfileByID
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string userDetails = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gLogedUserId", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                userDetails = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_LoggedUserDetails, ht, "gresult", StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                userDetails

            };
        }


        public async Task<object> GetApplicantProfileByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string userDetails = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gLogedUserId", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                userDetails = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_ApplicantProfileDetails, ht, "gresult", StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                userDetails

            };
        }

        /*        //START ------------------------------------------------------
                public List<dynamic> GetDistrict(string DivisionId)
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.CommandText = "hr_job_app.Address_Pkg.GetDistrictList";
                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    objCmd.Parameters.Add("p_OID", OracleDbType.Varchar2).Value = DivisionId;
                    //ConvertDataTableToGeniric classDt = new ConvertDataTableToGeniric();
                    DataTable dt =GetData(objCmd);

                    List<dynamic> list = new List<dynamic>();
                    foreach (DataRow row in dt.Rows)
                    {
                        dynamic item = new ExpandoObject();
                        foreach (DataColumn col in dt.Columns)
                        {
                            ((IDictionary<string, object>)item)[col.ColumnName] = row[col];
                        }
                        list.Add(item);
                    }
                    return list;
                }


                //RETRIVE Thana BY ID
                public List<dynamic> GetThanaList(string DistrictID)
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.CommandText = "hr_job_app.Address_Pkg.GetUpzlList";
                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    objCmd.Parameters.Add("p_OID", OracleDbType.Varchar2).Value = DistrictID;
                    //ConvertDataTableToGeniric classDt = new ConvertDataTableToGeniric();
                    DataTable dt = GetData(objCmd);

                    List<dynamic> list = new List<dynamic>();
                    foreach (DataRow row in dt.Rows)
                    {
                        dynamic item = new ExpandoObject();
                        foreach (DataColumn col in dt.Columns)
                        {
                            ((IDictionary<string, object>)item)[col.ColumnName] = row[col];
                        }
                        list.Add(item);
                    }
                    return list;
                }


                //ARIF EXTRRA---------------------START
                private string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=erpprd)(PORT=1525))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=hrdpdb)));User ID=hr_job_app;Password=hr_job_it;Persist Security Info=True";
                public DataTable GetData(OracleCommand objCmd)
                {
                    using (OracleConnection con = new OracleConnection(_connectionString))
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        using (OracleDataAdapter sda = new OracleDataAdapter())
                        {
                            objCmd.Connection = con;
                            sda.SelectCommand = objCmd;
                            sda.Fill(dt);
                            con.Close();
                            return dt;
                        }

                    }
                }

                //ARIF END ---------------------------------------------------*/

        //END------------------------------------------------------------------------------------
        public async Task<object> GetDistrictByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string districtList = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gJobDivId", (1, OracleDbType.Varchar2, cparam.id)}
                };
                districtList = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGetDistrict, ht, "gresult", StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                districtList

            };
        }


        public async Task<object> GetThanaByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string thanaList = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gJobDisId", (1, OracleDbType.Varchar2, cparam.id)}
                };
                thanaList = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGetThana, ht, "gresult", StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                thanaList

            };
        }


      /*  public async Task<object> testforFun( string _mJsonData,string _dJsonData,string _tcJsonData, string _proCirtificate,
            string _training,
            string _reference,
            vmCmnParameter param)
        {
            try
            {
                using (var conn = new OracleConnection(StaticInfos.conStringOracle.ToString()))
                {
                    await conn.OpenAsync();

                    string query = @"
                    INSERT INTO t_job_app_applicant_form (OID, NAME, EMAIL)
                    VALUES (:OxD, :NxME, :ExAIL)";

                    using (var cmd = new OracleCommand(query, conn))
                    {
                        // Parameter names must match exactly with those in the SQL query
                        cmd.Parameters.Add(new OracleParameter("OxD", "113"));
                        cmd.Parameters.Add(new OracleParameter("NxME", "zarifur Rahman"));
                        cmd.Parameters.Add(new OracleParameter("ExAIL", "zarif@gmail.com"));

                        int rows = await cmd.ExecuteNonQueryAsync();

                        // ✅ Return success message
                        return new
                        {
                            success = rows > 0,
                            message = rows > 0
                                ? "Data saved successfully."
                                : "No rows affected."
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Return error message if any exception occurs
                return new
                {
                    success = false,
                    message = "Error: " + ex.Message
                };
            }
        }
*/




        public async Task<object> SaveUpdate(string _mJsonData, string _dJsonData, string _tcJsonData,string _proCirtificate,string _training, string _reference, vmCmnParameter param)
    {
        object referenceId = 0; string message = string.Empty; bool resstate = false; string mstrId = string.Empty;
        OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
        string result1 = string.Empty, mstrRes = string.Empty;string result2 = string.Empty; string result3 = string.Empty; 
            string result4 = string.Empty; string result5 = string.Empty; string result6 = string.Empty;
            try
        {
            
            ocmd = new OracleCommand();
            ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
            ocmd.Parameters.Add("JsonData_Mstr", OracleDbType.Clob).Value = _mJsonData;
            ocmd.Parameters.Add("JsonData_TCN", OracleDbType.Clob).Value = _tcJsonData;
            ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
            ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

            mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_ApplicantFormMaster, ocmd, "mresult", StaticInfos.conStringOracle.ToString());

                if(!string.IsNullOrEmpty(mstrRes) && !string.IsNullOrEmpty(param.JobOid) && string.IsNullOrEmpty(param.mstrOid)){
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Email", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("JobId", OracleDbType.Varchar2).Value = param.JobOid;
                    ocmd.Parameters.Add("ProfileId", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    result4 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSetApplyApplicant, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }
            if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = _dJsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                  result1 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_ApplicantFormAcademicQlf, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                 
           
            }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = _tcJsonData;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                    result2 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_ApplicantFormWorkExp, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = _proCirtificate;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                    result3 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_ApplicantProfCirtifacate, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }//Ora_SpSet_ApplicantTraining
                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = _training;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                    result5 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_ApplicantTraining, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }
                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "null")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = _reference;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                    result6 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_ApplicantReference, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                


                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "0" && mstrRes != "null")
            {

                    message = MessageConstants.Saved;
                resstate = MessageConstants.SuccessState;
                    mstrId = mstrRes;
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
            resstate,
            mstrId
        };
    }




        public async Task<object> SaveUpdateMessage(string _mJsonData, vmCmnParameter param)
        {
            object referenceId = 0; string message = string.Empty; bool resstate = false;
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result1 = string.Empty, mstrRes = string.Empty; string result2 = string.Empty; string result3 = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData_Mstr", OracleDbType.Varchar2,3000).Value = _mJsonData;
                mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSetUpdateMessage, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "0" && mstrRes != "null")
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


        public async Task<object> saveUpdateJoiningApplicant(string _mJsonData, vmCmnParameter param)
        {
            dynamic data = JsonConvert.DeserializeObject<dynamic>(_mJsonData);
            string oid = data.oid; string salary = data.salary;DateTime date = data.joiningDate;
            string profileOid; string message = string.Empty; bool resstate = false; 
            try { 
                using (_ctxOra=new ModelContext())
                {
                    var applicant = await _ctxOra.TJobApplicantMainMasters.FirstOrDefaultAsync(x => x.Oid == oid);
                    if (applicant != null)
                    {
                        profileOid = applicant.Profileoid;
                        applicant.SetSalary = salary;
                        applicant.JoiningDate = date;
                        applicant.Isjoining = "1";
                        await _ctxOra.SaveChangesAsync();

                        var getProfile = await _ctxOra.TJobApplicantMasters.FirstOrDefaultAsync(x => x.Oid == profileOid);
                        if (getProfile != null)
                        {
                            getProfile.SetSalary = salary;
                            getProfile.JoiningDate = date;
                            getProfile.Isjoining = "1";
                            await _ctxOra.SaveChangesAsync();
                        }
                        message = MessageConstants.Saved;
                        resstate = MessageConstants.SuccessState;

                    }
                    else
                    {
                        message = MessageConstants.SavedWarning;
                    }

                }

            }
            catch (Exception ex) { }
            return new { 
                message ,
                resstate
            };
        }

        public async Task<object> saveUpdateVerifyApplicant(string _mJsonData, vmCmnParameter param)
        {
            dynamic data = JsonConvert.DeserializeObject<dynamic>(_mJsonData);
            string oid = data.oid; string note = data.note; DateTime date = DateTime.Now;
            bool isVerify=data.isVerify;bool isVerifyDecline = data.isVerifyDecline;
            string message = string.Empty; bool resstate = false;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    var applicant = await _ctxOra.TJobApplicantMainMasters.FirstOrDefaultAsync(x => x.Oid == oid);
                    if (applicant != null)
                    {
                        applicant.Verifydecnote = note;
                        if (isVerify == true)
                        {
                            applicant.Isverify = "1";
                            applicant.Isverifydecline = null;
                            applicant.VerifyDate = date;
                            applicant.Verifyby = param.LoggedUserId;
                        }
                        else
                        {
                            applicant.Isverifydecline = "1";
                            applicant.Isverify = null;
                            applicant.Vdeclndate = date;
                            applicant.Vdeclvby = param.LoggedUserId;
                        }
                        
                        
                        await _ctxOra.SaveChangesAsync();

                    
                        message = MessageConstants.Saved;
                        resstate = MessageConstants.SuccessState;

                    }
                    else
                    {
                        message = MessageConstants.SavedWarning;
                    }

                }

            }
            catch (Exception ex) { }
            return new
            {
                message,
                resstate
            };
        }


        public async Task<object> saveUpdateApproveApplication(string _mJsonData, vmCmnParameter param)
        {
            dynamic data = JsonConvert.DeserializeObject<dynamic>(_mJsonData);
            string oid = data.oid; string note = data.note; DateTime date = DateTime.Now;
            string isApprove = data.isApprove; 
            string message = string.Empty; bool resstate = false;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    var applicant = await _ctxOra.TJobApplicantMainMasters.FirstOrDefaultAsync(x => x.Oid == oid);
                    if (applicant != null)
                    {
                        applicant.Approvedecnote = note;
                        if (isApprove == "A")
                        {
                            applicant.Isapprove = "1";
                            applicant.Isaprvdecln = null;
                            applicant.Approvedate = date;
                            applicant.Approveby = param.LoggedUserId;

                            dynamic empOid = await SaveApplicantToApply(applicant.Profileoid, param);
                            if (empOid.mstrRes != null)
                            {
                                applicant.EmpOid = empOid.mstrRes;
                            }
                        }
                        else if (isApprove == "R")
                        {
                            applicant.Isapprove = null;
                            applicant.Isaprvdecln = "1";
                            applicant.Isverify = "3";
                            applicant.Aprvdeclndate = date;
                            applicant.Aprvdeclnby = param.LoggedUserId;
                        }
                        else if(isApprove == "B")
                        {
                            applicant.IsAprvrevision = "1";
                            applicant.Isverify = "2";
                            applicant.AprvrevisionDate = date;
                            applicant.AprvrevisionBy = param.LoggedUserId;
                        }


                        await _ctxOra.SaveChangesAsync();


                        message = MessageConstants.Saved;
                        resstate = MessageConstants.SuccessState;

                    }
                    else
                    {
                        message = MessageConstants.SavedWarning;
                    }

                }

            }
            catch (Exception ex) { }
            return new
            {
                message,
                resstate
            };
        }


        public async Task<object> SaveApplicantToApply(string applicantOid, vmCmnParameter param)
        {
            object referenceId = 0; string message = string.Empty; bool resstate = false;
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result1 = string.Empty, mstrRes = string.Empty; string result2 = string.Empty; string result3 = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("ProfileId", OracleDbType.Varchar2, 50).Value = applicantOid;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2, 3000).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSetEmployeeFromApplicant, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "0" && mstrRes != "null")
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
                mstrRes,
                resstate
            };
        }



        public async Task<object> saveApplicantJobApply(vmCmnParameter param)
        {
            object referenceId = 0; string message = string.Empty; bool resstate = false;
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result1 = string.Empty, mstrRes = string.Empty; string result2 = string.Empty; string result3 = string.Empty;
            try
            {

                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("Email", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("JobId", OracleDbType.Varchar2).Value = param.JobOid;
                ocmd.Parameters.Add("ProfileId", OracleDbType.Varchar2).Value = param.strId2;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                if (!string.IsNullOrEmpty(param.JobOid) && !string.IsNullOrEmpty(param.strId2))
                {
                    mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSetApplyApplicant, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }
               
                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "0" && mstrRes != "null")
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



        public async Task<object> GetApplcntByID(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string regApplicantDetails = string.Empty, wrkOrdrDetail = string.Empty, wrkDtl = string.Empty, termsCondition = string.Empty, objFlowDetail = string.Empty;
            try
            {
                var PrcsFlowMgt = new ProcessFlowMgt();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gApplicantMobNum", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                //gQuotationId
                regApplicantDetails = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGetApplicantDetailByMobNum, ht, "gresult", StaticInfos.conStringOracle.ToString());
           
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                regApplicantDetails
             
            };
        }




        public async Task<object> GetWithPaginationById(vmCmnParameter param) //vmCmnParameters cmnParam
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listApplication = string.Empty;
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

                listApplication = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_AlldataByPageById, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listApplication
            };
        }





        public async Task<object> getcandiDatedetailsByid(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string regApplicantMaster = string.Empty, accQlfDetail = string.Empty, wrkExperience = string.Empty, 
            profCertificate = string.Empty, training = string.Empty , reference = string.Empty;
            try
            {
                var PrcsFlowMgt = new ProcessFlowMgt();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gCandiDateMstById", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                //gQuotationId
                regApplicantMaster = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateDetailsById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                accQlfDetail = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidatAccQualificatonById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                wrkExperience = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateDeWorkExperienceById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                profCertificate = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateProfCirtificateById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                training = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateTrainingById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                reference = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateReferenceById, ht, "gresult", StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                regApplicantMaster,
                accQlfDetail,
                wrkExperience,
                profCertificate,
                training,
                reference

            };
        }


        public async Task<object> getApplicationDetalByid(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string regApplicantMaster = string.Empty, accQlfDetail = string.Empty, wrkExperience = string.Empty, profCertificate = string.Empty,
                training = string.Empty , reference = string.Empty, aprovalCheckLstMaster=string.Empty, approvalXmlist=string.Empty;
            try
            {
                var PrcsFlowMgt = new ProcessFlowMgt();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gCandiDateMstById", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                //gQuotationId
                
                regApplicantMaster = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_ApplicationDetailsById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                aprovalCheckLstMaster = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateAprvlChckMstrById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(aprovalCheckLstMaster))
                {
                    var xmDetails = System.Text.Json.JsonSerializer.Deserialize<List<JsonElement>>(aprovalCheckLstMaster);
                    string aprvChklstOid = xmDetails[0].GetProperty("aprvRecruitmentOid").GetString();
                    gt = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gCandiDateMstById", (1, OracleDbType.Varchar2, aprvChklstOid)}
                };
                    approvalXmlist = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateAprvlXmById, gt, "gresult", StaticInfos.conStringOracle.ToString());
                   

                }
                if (regApplicantMaster != "null")
                {
                    var applicants = System.Text.Json.JsonSerializer.Deserialize<List<JsonElement>>(regApplicantMaster);
                    string profileOid = applicants[0].GetProperty("profileOid").GetString();

                    gt = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gCandiDateMstById", (1, OracleDbType.Varchar2, profileOid)}
                };
                    accQlfDetail = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidatAccQualificatonById, gt, "gresult", StaticInfos.conStringOracle.ToString());
                    wrkExperience = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateDeWorkExperienceById, gt, "gresult", StaticInfos.conStringOracle.ToString());
                    profCertificate = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateProfCirtificateById, gt, "gresult", StaticInfos.conStringOracle.ToString());
                    training = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateTrainingById, gt, "gresult", StaticInfos.conStringOracle.ToString());
                    reference = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_CandidateReferenceById, gt, "gresult", StaticInfos.conStringOracle.ToString());




                }

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                regApplicantMaster,
                accQlfDetail,
                wrkExperience,
                profCertificate,
                training,
                reference,
                aprovalCheckLstMaster,
                approvalXmlist

            };
        }



        public async Task<object> GetRegularReport(vmReportModel rptm, vmCmnParameter cparam)
        {
            object bytes = null; bool resstate = false;
            try
            {
                dynamic objRes = await getcandiDatedetailsByid(cparam);
                var dataListMstr = Extension.GetReportDataTable(objRes.regApplicantMaster.ToString());
                var dataListAccQlf = Extension.GetReportDataTable(objRes.accQlfDetail.ToString());
                var dataListWrkExp = Extension.GetReportDataTable(objRes.wrkExperience.ToString());
                var dataListProfCir = Extension.GetReportDataTable(objRes.profCertificate.ToString());
                var dataListTraining = Extension.GetReportDataTable(objRes.training.ToString());
                var dataListReference = Extension.GetReportDataTable(objRes.reference.ToString());
                //var dataListAprChckMstr = Extension.GetReportDataTable(objRes.aprovalCheckLstMaster.ToString());
                //var dataLisAprvXmList = Extension.GetReportDataTable(objRes.approvalXmlist.ToString());


                dataListMstr = Extension.AddDataSetName(dataListMstr, "DataSet1");
                rptm.DataTableList.Add(dataListMstr);

                dataListAccQlf = Extension.AddDataSetName(dataListAccQlf, "DataSet2");
                rptm.DataTableList.Add(dataListAccQlf);

                dataListWrkExp = Extension.AddDataSetName(dataListWrkExp, "DataSet3");
                rptm.DataTableList.Add(dataListWrkExp);

                dataListProfCir = Extension.AddDataSetName(dataListProfCir, "DataSet4");
                rptm.DataTableList.Add(dataListProfCir);

                dataListTraining = Extension.AddDataSetName(dataListTraining, "DataSet5");
                rptm.DataTableList.Add(dataListTraining);

                dataListReference = Extension.AddDataSetName(dataListReference, "DataSet6");
                rptm.DataTableList.Add(dataListReference);

               /* dataListAprChckMstr = Extension.AddDataSetName(dataListAprChckMstr, "DataSet7");
                rptm.DataTableList.Add(dataListAprChckMstr);

                dataLisAprvXmList = Extension.AddDataSetName(dataLisAprvXmList, "DataSet8");
                rptm.DataTableList.Add(dataLisAprvXmList);*/

                bytes = ReportingService.Report(rptm).Result;

                if (bytes != null && bytes != string.Empty)
                {
                    resstate = true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                bytes,
                resstate
            };
        }


        //GET REPORT FOR INDIVIDUAL ALL APPLICATION
        public async Task<object> GetApplicantReport(vmReportModel rptm, vmCmnParameter cparam)
        {
            object bytes = null; bool resstate = false;
            try
            {
                dynamic objRes = await getApplicationDetalByid(cparam);
                var dataListMstr = Extension.GetReportDataTable(objRes.regApplicantMaster.ToString());
                var dataListAccQlf = Extension.GetReportDataTable(objRes.accQlfDetail.ToString());
                var dataListWrkExp = Extension.GetReportDataTable(objRes.wrkExperience.ToString());
                var dataListProfCir = Extension.GetReportDataTable(objRes.profCertificate.ToString());
                var dataListTraining = Extension.GetReportDataTable(objRes.training.ToString());
                var dataListReference = Extension.GetReportDataTable(objRes.reference.ToString());
                var dataListAprChckMstr = Extension.GetReportDataTable(objRes.aprovalCheckLstMaster.ToString());
                var dataLisAprvXmList = Extension.GetReportDataTable(objRes.approvalXmlist.ToString());


                dataListMstr = Extension.AddDataSetName(dataListMstr, "DataSet1");
                rptm.DataTableList.Add(dataListMstr);

                dataListAccQlf = Extension.AddDataSetName(dataListAccQlf, "DataSet2");
                rptm.DataTableList.Add(dataListAccQlf);

                dataListWrkExp = Extension.AddDataSetName(dataListWrkExp, "DataSet3");
                rptm.DataTableList.Add(dataListWrkExp);

                dataListProfCir = Extension.AddDataSetName(dataListProfCir, "DataSet4");
                rptm.DataTableList.Add(dataListProfCir);

                dataListTraining = Extension.AddDataSetName(dataListTraining, "DataSet5");
                rptm.DataTableList.Add(dataListTraining);

                dataListReference = Extension.AddDataSetName(dataListReference, "DataSet6");
                rptm.DataTableList.Add(dataListReference);

               dataListAprChckMstr = Extension.AddDataSetName(dataListAprChckMstr, "DataSet7");
               rptm.DataTableList.Add(dataListAprChckMstr);

              dataLisAprvXmList = Extension.AddDataSetName(dataLisAprvXmList, "DataSet8");
              rptm.DataTableList.Add(dataLisAprvXmList);

                bytes = ReportingService.Report(rptm).Result;

                if (bytes != null && bytes != string.Empty)
                {
                    resstate = true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                bytes,
                resstate
            };
        }


        //GET JOB ID FROM JOB POST MASTER
        public async Task<object> getJobIdByMail(vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string jobIDList = string.Empty;
            try
            {
                var PrcsFlowMgt = new ProcessFlowMgt();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gUserId", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                //gQuotationId
                jobIDList = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.Ora_SpGet_FindJobIdFrmMasterData, ht, "gresult", StaticInfos.conStringOracle.ToString());
               
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                jobIDList,
         

            };
        }


        //DELETE A DOCUMENT FORM DATABASE 
        public async Task<Boolean> RemoveDocument(string id,string name)  
        {
            int docId = int.Parse(id);
            try
            {
                using (_ctxOra = new ModelContext()) {
                var doc=await _ctxOra.TJobApplicantDocuments .FirstOrDefaultAsync(rs => rs.Documentid == docId);
                    if(doc != null)
                    {
                        //start delete file from server
                        if (!string.IsNullOrEmpty(doc.Documentfullpath) && System.IO.File.Exists(doc.Documentfullpath))
                        {
                            try
                            {
                                System.IO.File.Delete(doc.Documentfullpath);//Virtualpath Documentfullpath
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Failed to delete old file: {ex.Message}");
                            }
                        }
                        //end delete file from server 

                        _ctxOra.Remove(doc);
                        await _ctxOra.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }

            }
            catch(Exception ex) { };
            return true;
            }






        public async Task<object> SaveUpdateRecruitmentApproval(string _mJsonData, string _dJsonData, vmCmnParameter param)
        {
            object referenceId = 0; string message = string.Empty; bool resstate = false; string mstrId = string.Empty;
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result1 = string.Empty, mstrRes = string.Empty; string result2 = string.Empty; string result3 = string.Empty;
            try
            {

                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData_Mstr", OracleDbType.Clob).Value = _mJsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                mstrRes = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSetApprovalCheckLstMstr, ocmd, "mresult", StaticInfos.conStringOracle.ToString());

                if (!string.IsNullOrEmpty(mstrRes)  && string.IsNullOrEmpty(param.mstrOid))
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = mstrRes;
                    ocmd.Parameters.Add("JsonData_Exam", OracleDbType.Clob).Value = _dJsonData;
                    // ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    result2 = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSetApprovalCheckLstExam, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }

                if (!string.IsNullOrEmpty(mstrRes))
                {
                    await saveUpdateVerify(_mJsonData, param);
                }

           



                if (!string.IsNullOrEmpty(mstrRes) && mstrRes != "0" && mstrRes != "null")
                {

                    message = MessageConstants.Saved;
                    resstate = MessageConstants.SuccessState;
                    mstrId = mstrRes;
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
                resstate,
                mstrId
            };
        }



        public async Task<object> saveUpdateVerify(string _mJsonData, vmCmnParameter param)
        {
            dynamic data = JsonConvert.DeserializeObject<dynamic>(_mJsonData);

            string oid = data[0].applicantOid;string preparedNote=data[0].preparedNote; 
            DateTime date = DateTime.Now;

            string message = string.Empty;
            bool resstate = false;

            try
            {
                if (string.IsNullOrWhiteSpace(oid))
                {
                    return new
                    {
                        message = "Invalid Applicant Id",
                        resstate = false
                    };
                }

                using (_ctxOra = new ModelContext())
                {
                    var applicant = await _ctxOra.TJobApplicantMainMasters
                                                .FirstOrDefaultAsync(x => x.Oid == oid);

                    if (applicant != null)
                    {
                        // 🔥 You can make this dynamic if needed
                        bool isVerify = true;

                        if (isVerify)
                        {
                            applicant.Isverify = "1";
                            applicant.Isverifydecline = null;
                            applicant.VerifyDate = date;
                            applicant.Verifyby = param.LoggedUserId;
                            applicant.Verifydecnote = preparedNote;
                        }
                     /*   else
                        {
                            applicant.Isverifydecline = "1";
                            applicant.Isverify = null;
                            applicant.Vdeclndate = date;
                            applicant.Vdeclvby = param.LoggedUserId;
                        }*/

                        await _ctxOra.SaveChangesAsync();

                        message = MessageConstants.Saved;
                        resstate = MessageConstants.SuccessState;
                    }
                    else
                    {
                        message = MessageConstants.SavedWarning;
                        resstate = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);   // ✅ proper logging
                message = "Error occurred";
                resstate = false;
            }

            return new
            {
                message,
                resstate
            };
        }















    }

    //------------------------------------------End-----------------------------------



















}
