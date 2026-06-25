using DataFactories.Infrastructure.common.dropdown;
using DataModel.ViewModels;
using DataUtility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CTG_ERPWebApi.api.common.dropdown
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class ereqdropdownController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private EreqCommonDropdownMgt _manager = null;
        #endregion

        #region Constructor
        public ereqdropdownController()
        {
            //_manager = new CommonDropdownMgt();
            _manager=  new EreqCommonDropdownMgt();
        }
        #endregion





        // GET: api/ereqdropdown/getallrole
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallrole()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllRole();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }











        // GET: api/ereqdropdown/getallroleForReopen
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalluserbycompany([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetAllUserByCompany(cparam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/ereqdropdown/getallcompanyuser
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallcompanyuser([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetAllCompanyUser(cparam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }




        //-----------------------CANDIDATE DATA START FROM HERE--------------------------------------

        // GET: api/ereqdropdown/getallcompanyuser
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallcompanycandidate()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getallcompanycandidate();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/ereqdropdown/getallcompanyuser
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getalldepartmentcandidate()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getalldepartmentcandidate();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/ereqdropdown/getallcompanyuser
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallpostcandidate()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getallpostcandidate();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        [HttpGet("[action]")]
        public async Task<object> getallaccqlf()
        {
            object reslut = null; object resdata = null;
            try
            {
                resdata = await _manager.getAllAcqlfList();
            }
            catch (Exception) { }
            return reslut = new
            {
                resdata
            };
        }

        //GET ALL JOB POST 
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getalljobtitle()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getalljobtitle();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        //GET 

        // GET: api/ereqdropdown/get DISTRICT BY ID
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getaUserInfoById(string id)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getaUserInfoById(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/ereqdropdown/get DISTRICT BY ID
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getProfileInfoById(string id)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getaProfileInfoById(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getaUserInfoByRoleId(string id)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getaUserInfoByRoleId(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }



        //DELETE/INACTIVE  JOB POST MASTER 
        // GET: api/ereqdropdown/get DISTRICT BY ID
        // PUT: api/ereqdropdown/DeleteJobPostById
        [HttpPut("[action]")]
        public async Task<IActionResult> DeleteJobPostById(string id)
        {
            try
            {
                var result = await _manager.DeleteJobPostById(id);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return StatusCode(500, new { success = false, message = "An error occurred while deleting the job post." });
            }
        }

        //GET: api/ereqdropdown/getallbusinesstype
        [HttpGet("[action]")]
        public async Task<object> getallbusinesstype()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllBusinessType();
            }
            catch (Exception) { }
            return result = new
            {
                resdata

            };
        }

        //GET: api/ereqdropdown/getbusinesstypebyid
        [HttpGet("[action]")]
        public async Task<object> getbusinesstypebyid(string id)
        {
            object result = null; object resdata = null;
            try {
                resdata = await _manager.GetBusinessTypeById(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdateexaminar([FromBody] object[] data)
        {
            object resdata = null;
            try
            {
                if (!string.IsNullOrEmpty(data.ToString()))
                {
                    resdata = await _manager.saveExaminar(data);
                }
            }
            catch (Exception) { }

            return new
            {
                resdata
            };
        }





    }
}