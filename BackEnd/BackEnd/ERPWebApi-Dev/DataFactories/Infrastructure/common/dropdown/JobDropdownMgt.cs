using DataFactories.BaseFactory;
using DataModel.JobEntityModel.HrJobTable;



//using DataModels.EntityModels.ERPModel;
//using DataModel.JobEntityModels.HrJobTable;
//using DataModel.EntityModels.ISPModel;
using DataModel.ViewModels;
//using DataModels.ViewModels.ERPViewModel.Business.Cloud;
//using DataModels.ViewModels.ERPViewModel.SalesMarketing;
using DataUtility;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFactories.Infrastructure.common.dropdown
{
    public class JobCommonDropdownMgt
    {

        #region Variable declaration & initialization
        //dbRGLERPContext _ctx = null;
        ModelContext _ctxOr = null;
       
       
        //radiusContext _ctxRad = null;
        //private IGenericFactory<vmCmnParameters> Generic_vmCmnParameters = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        Hashtable ht = null;
        #endregion

        #region security


        //-----------------------------------Start------------------------------------------------
        public async Task<object> GetAllDivision()
        {
            object listAllDiv = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAllDiv = await (from tct in _ctxOr.TDivisions
                                        select new
                                        {
                                            oId = tct.Oid,
                                            divName = tct.DivName
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
                listAllDiv
            };
        }

//GET ALL DISTRICT--------------------------------
        public async Task<object> getallDistrictById(string id)
        {
            object listAllDis = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAllDis = await (from tct in _ctxOr.TDists
                                        where tct.DivOid == id
                                        select new
                                        {
                                            oId = tct.Oid,
                                            disName = tct.DistName
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
                listAllDis
            };
        }



        //GET ALL DISTRICT--------------------------------
        public async Task<object> getallthanaById(string id)
        {
            object listAllThna = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAllThna = await (from tct in _ctxOr.TUpzls
                                        where tct.UpzlDist == id
                                        select new
                                        {
                                            oId = tct.Oid,
                                            thanaName = tct.UpzlName
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
                listAllThna
            };
        }




        public async Task<object> GetAllCompany()
        {
            object listAllComp = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAllComp = await (from tct in _ctxOr.TAcmps
                                         where tct.AcmpActv == "Y"
                                         select new
                                         {
                                             oId = tct.Oid,
                                             divName = tct.AcmpName
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
                listAllComp
            };
        }


        public async Task<object> GetAllDepartment()
        {
            object listAllDept = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAllDept = await (from tct in _ctxOr.TDepts
                                         where tct.DeptActv == "Y"
                                         select new
                                         {
                                             oId = tct.Oid,
                                             deptName = tct.DeptName
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
                listAllDept
            };
        }


        public async Task<object> GetAllDesignation()
        {
            object listAllDes = null; object result = null;
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    listAllDes = await (from tct in _ctxOr.TDsigs
                                        where tct.DsigActv == "Y"
                                        select new
                                        {
                                            oId = tct.Oid,
                                            dsigName = tct.DsigName
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
                listAllDes
            };
        }


 
        //-----------------------------------End-------------------------------------------------
        //GET ALL BRAND


        #endregion
    }
}
