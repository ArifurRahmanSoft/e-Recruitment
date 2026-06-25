using DataFactories.Infrastructure.common.userroles;
//using DataModels.EntityModels.ERPModel;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTG_ERPWebApi.api.common.userroles
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class jobuserRoleController : ControllerBase
    {

        #region Variable Declaration & Initialization
        private JobUserRoleMgt _manager = null;
        #endregion

        #region Constructor
        public jobuserRoleController()
        {
            _manager = new JobUserRoleMgt();
        }
        #endregion

        #region All Http Methods
        // GET: api/role/getbypage
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbypage([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetWithPagination(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapprovalbypage([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetApprovalPagination(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        
        // GET: api/role/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/role/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapprovalbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetApprovalByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        

        // POST: api/role/saveupdate
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdate([FromBody]object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                vmRoles _UserRole = JsonConvert.DeserializeObject<vmRoles>(data[1].ToString());
                if (_UserRole != null)
                {
                    resdata = await _manager.SaveUpdate(_UserRole, cparam);
                }
            }
            catch (Exception) { }

            return result = new
            {
                resdata
            };
        }


        //POST: api/role/saveupdate
        [HttpPost("[action]")]
        public async Task<object> saveUpdateApproval([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                vmRoles _UserRole = JsonConvert.DeserializeObject<vmRoles>(data[1].ToString());
                if (_UserRole != null)
                {
                    resdata = await _manager.SaveUpdateApproval(_UserRole, cparam);
                }

            }
            catch (Exception) { }

            return result = new
            {
                resdata
            };
            
        }


        
           [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapprovalbyuserid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetApprovalByUserID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // DELETE: api/role/delete
        [HttpDelete("[action]")]//BasicAuthorization
        public async Task<object> delete([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.Delete(cparam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }
        #endregion
    }
}
