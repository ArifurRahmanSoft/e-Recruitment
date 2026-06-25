using DataFactories.BaseFactory;


//using DataModels.EntityModels.ERPModel;
//using DataModel.EntityModels.OraModel;
using DataModel.JobEntityModel.JobOraModelTest;

//using DataModel.EntityModels.ISPModel;
using DataModel.ViewModels;
//using DataModels.ViewModels.ERPViewModel.Business.Cloud;
//using DataModels.ViewModels.ERPViewModel.SalesMarketing;
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataFactories.Infrastructure.common.dropdown
{
    public class EreqCommonDropdownMgt 
    {

        #region Variable declaration & initialization
        //dbRGLERPContext _ctx = null;
        //ModelContext _ctxOr = null;
        ModelContext _ctxOr = null;
    
        
        //radiusContext _ctxRad = null;
        //private IGenericFactory<vmCmnParameters> Generic_vmCmnParameters = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        Hashtable ht = null;
        #endregion

        #region security
        /// <summary>
        /// This method returns data from database as a list of Module object using asynchronous operation by an int parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<object> GetAllModule()
        //{
        //    List<CmnModule> listModule = null; object result = null;
        //    try
        //    {
        //        using (_ctx = new dbRGLERPContext())
        //        {
        //            listModule = await _ctx.CmnModule
        //                .OrderBy(o => o.ModuleName)
        //                .ToListAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logs.WriteBug(ex);
        //    }
        //    return result = new
        //    {
        //        listModule
        //    };
        //}

        ///// <summary>
        ///// This method returns data from database as a list of Menu object using asynchronous operation by an int parameter.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<object> GetAllMenu()
        //{
        //    List<CmnMenu> listMenues = null; object result = null;
        //    try
        //    {
        //        using (_ctx = new dbRGLERPContext())
        //        {
        //            listMenues = await _ctx.CmnMenu.ToListAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logs.WriteBug(ex);
        //    }

        //    return result = new
        //    {
        //        listMenues
        //    };
        //}



        //// GET: api/dropdown/getallroleForReopen
        //public async Task<object> GetAllRoleFroReopenGroup(int id)
        //{
        //    List<CmnUserRole> listUsrRole = null; object result = null;
        //    try
        //    {
        //        using (_ctx = new dbRGLERPContext())
        //        {
        //            List<CmnUserRole> role = await _ctx.CmnUserRole
        //                .Join(_ctx.BizIspUserPackServiceReopenGroup, x => x.RoleId, y => y.RoleId, (x, y) => new CmnUserRole { RoleId = x.RoleId, RoleName = x.RoleName, CompanyId = x.CompanyId, IsActive = x.IsActive, CreateDate = x.CreateDate, CreatedBy = x.CreatedBy })
        //                .OrderBy(a => a.RoleName)
        //                .ToListAsync();
        //            listUsrRole = await _ctx.CmnUserRole.Where(x => x.RoleId != StaticInfos.SeedRoleID).Where(c => !role.Contains(c)).ToListAsync();
        //            if (id > 0)
        //            {
        //                var userrole = await _ctx.CmnUserRole.FindAsync(id);
        //                listUsrRole.Add(userrole);
        //            }
        //            //listUsrRole = listUsrRole.Except(role).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logs.WriteBug(ex);
        //    }

        //    return result = new
        //    {
        //        listUsrRole
        //    };
        //}

        ///// <summary>
        ///// This method returns data from database as a list of Role object using asynchronous operation by an int parameter.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<object> GetAllRoleBak()
        //{
        //    List<CmnUserRole> listUsrRole = null; object result = null;
        //    try
        //    {
        //        using (_ctx = new dbRGLERPContext())
        //        {
        //            listUsrRole = await _ctx.CmnUserRole
        //                .Where(x => x.RoleId != StaticInfos.SeedRoleID)
        //                .OrderBy(a => a.RoleName)
        //                .ToListAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logs.WriteBug(ex);
        //    }

        //    return result = new
        //    {
        //        listUsrRole
        //    };
        //}


        //GET ALL BRAND
      


        public async Task<object> GetAllRole()
        {
            object listUsrRole = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listUsrRole = await (from rs in _ctxOr.TRoleSetups
                                         where rs.Roleid != StaticInfos.SeedRoleID
                                         select new
                                         {
                                             roleId = rs.Roleid,
                                             roleName = rs.Rolename
                                         }
                                      ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return result = new
            {
                listUsrRole
            };
        }


        //------------------------------------Start Candidate----------------------------------

            public async Task<object> getallcompanycandidate()
            {
            object listCompany = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listCompany = await (from rs in _ctxOr.TJobApplicantMasters
                                             // where rs.Roleid != StaticInfos.SeedRoleID
                                         where !string.IsNullOrEmpty(rs.CompanyName)
                                         select new
                                         {
                                             companyName = rs.CompanyName,
                                             //roleName = rs.Rolename
                                         }
                                      )
                                      .Distinct()
                                      .ToListAsync();
                }
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


        public async Task<object> getalldepartmentcandidate()
        {
            object listDepartment = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listDepartment = await (from rs in _ctxOr.TJobApplicantMasters
                                            where !string.IsNullOrEmpty(rs.Department)
                                            select new
                                         {
                                             department = rs.Department,
                                             //roleName = rs.Rolename
                                         }
                                      )
                                      .Distinct()
                                      .ToListAsync();
                }
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

        public async Task<object> getallpostcandidate()
        {
            object listPost = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listPost = await (from rs in _ctxOr.TJobApplicantMasters
                                      where !string.IsNullOrEmpty(rs.AppliedPost)
                                      select new
                                         {
                                             postName = rs.AppliedPost,
                                             //roleName = rs.Rolename
                                         }
                                      )
                                      .Distinct()
                                      .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return result = new
            {
                listPost
            };
        }

        public async Task<object> getAllAcqlfList()
        {
            object listAccQlf = null;object result = null;
          try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAccQlf = await (from rs in _ctxOr.TAcqlves
                                        select new
                                        {
                                            Oid = rs.Oid,
                                            degree = rs.DegreeName
                                        })
                             .Distinct()
                             .ToListAsync();
                }
            }
            catch(Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listAccQlf
            };
        }

        public async Task<object> getalljobtitle()
        {
            object listJob = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listJob = await (from rs in _ctxOr.TAdminJobPostMasters
                                      //where !string.IsNullOrEmpty(rs.)
                                      select new
                                      {
                                          jobTitle = rs.JobTitle,
                                          jobID = rs.Oid,
                                          jobEndDate = rs.EndDate,
                                      }
                                      )
                                      .Distinct()
                                      .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return result = new
            {
                listJob
            };
        }

        

        //--------------------------------------End-----------------------------------------------------




        public async Task<object> GetAllUserByCompany(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listUser = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "uresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "s_CompanyID", (1, param.values) }
                };

                listUser = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_UserByCompany, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listUser
            };
        }

        public async Task<object> GetAllCompanyUser(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listUser = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "uresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "s_CompanyID", (1, param.values) }
                };

                listUser = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_CompanyUser, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listUser
            };
        }



        //user info for role
        public async Task<object> getaUserInfoById(string id)
        {
            object listuserInfo = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listuserInfo = await (from tct in _ctxOr.TSysUsers
                                         where tct.Userid == id
                                         select new
                                         {
                                             email = tct.Email,
                                             userRole = tct.Designation
                                         }
                                      ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return result = new
            {
                listuserInfo
            };
        }


        //user info for role
        public async Task<object> getaProfileInfoById(string id)
        {
            object listuserInfo = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listuserInfo = await (from tct in _ctxOr.TJobApplicantMasters
                                          where tct.Email == id
                                          select new
                                          {
                                              oid = tct.Oid,
                                              //JobOid = tct.Jobid,
                                              email=tct.Email
                                          }
                                      ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return result = new
            {
                listuserInfo
            };
        }
        //End


        public async Task<object> getaUserInfoByRoleId(string id)
        {
            object listuserInfo = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listuserInfo = await (from tct in _ctxOr.TUserRoles
                                          where tct.UserId == id
                                          select new
                                          {
                                              email = tct.UserId,
                                              userRole = tct.RoleId
                                          }
                                      ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return result = new
            {
                listuserInfo
            };
        }
        //End
        

        //user info for role
        public async Task<object> DeleteJobPostById(string id)
        {
            object result = null;

            try
            {
                using (var _ctxOr = new ModelContext())
                {
                    var jobPost = await _ctxOr.TAdminJobPostMasters
                        .FirstOrDefaultAsync(j => j.Oid == id);

                    if (jobPost != null)
                    {
                        jobPost.Isactive = "0";  // Mark as inactive
                        jobPost.Iscancel = "1";  // Mark as cancelled

                        _ctxOr.TAdminJobPostMasters.Update(jobPost);
                        await _ctxOr.SaveChangesAsync();

                        result = new
                        {
                            message = "Job post successfully deleted (soft delete)",
                            jobPostId = id
                        };
                    }
                    else
                    {
                        result = new
                        {
                            message = "Job post not found",
                            jobPostId = id
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                result = new
                {
                    message = "An error occurred",
                    error = ex.Message
                };
            }

            return result;
        }

        //End

        public async Task<object> GetAllBusinessType()
        {
            object listAllBusiness = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {

                  
                    listAllBusiness = await (from bsns in _ctxOr.TAdminApplicantBusinesses

                                             select new
                                             {
                                                 name = bsns.Name,
                                                 id = bsns.Oid
                                             }
                                             ).ToListAsync(); 
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listAllBusiness
            };
        }


        public async Task<object> GetBusinessTypeById(string id)
        {
            object result = null;object businessType = null;
            try {

                using (_ctxOr = new ModelContext())
                {
                    businessType = await (from x in _ctxOr.TAdminApplicantBusinesses
                                          where x.Oid == id
                                          select new
                                          {
                                              businessOid=x.Oid,
                                              name=x.Name,
                                              details=x.Details
                                          }
                                        ).ToListAsync();
                }
            }
            catch(Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                businessType
            };
        }



        public async Task<object> saveExaminar(object[] data)
        {
           vmCmnParameter param= JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string json_data = data[1].ToString();
            JArray arr = JArray.Parse(json_data);
            var firstArr = arr[0];
            string aempOid = firstArr["empOId"]?.ToString();
            string empId=firstArr["empId"]?.ToString();
            try
            {
                using (_ctxOr = new ModelContext())
                {

                    var existUser = await _ctxOr.TJobRecruitmentExaminers.FirstOrDefaultAsync(x => x.AempOid == aempOid);
                    if (existUser != null)
                    {
                        return new
                        {
                            status = "error",
                            message = "Employee already exists!"
                        };
                    }

                    var maxId = await _ctxOr.TJobRecruitmentExaminers.MaxAsync(x => (int?)Convert.ToInt32(x.Oid)) ?? 0;
                    var newOid = maxId + 1;


                    if (existUser == null)
                    {
                        var newExaminar = new TJobRecruitmentExaminer
                        {
                            Oid = newOid.ToString(),
                            AempOid = aempOid,
                            EmpId = empId,
                            Createby = param.LoggedUserId,
                            Createon = DateTime.Today,
                            Createpc = Extension.Createpc()

                        };
                        _ctxOr.TJobRecruitmentExaminers.Add(newExaminar);
                        await _ctxOr.SaveChangesAsync();

                    }
                }

                return new
                {
                    status = "success",
                    message = "Examiner saved successfully"
                };


            }

            catch(Exception ex)
            {
                return new
                {
                    status = "error",
                    message = ex.Message
                };
            }

        }


    

        #endregion


    }
}
