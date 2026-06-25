using DataFactories.Infrastructure.business.businessconfigure;
using DataFactories.Infrastructure.business.jobpost;
using DataModel.ViewModels.ERPViewModel.Business;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using DataModel.ViewModels.ERPViewModel.Common;
using DataFactories.Infrastructure.business.workorder;

namespace CTG_ERPWebApi.api.business.jobpost
{
   // [Route("api/[controller]")]
[Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
[ApiController]
public class JobPostController : ControllerBase
{
        private IWebHostEnvironment _hostingEnvironment;

        #region Variable Declaration & Initialization
        private JobPostMgt _manager = null;
        private BusinessSetupMgt _srvManager = null;
        #endregion

        #region Constructor
        public JobPostController(IWebHostEnvironment hostingEnvironment)
        {
           
            _manager = new JobPostMgt();
            _srvManager = new BusinessSetupMgt();
            _hostingEnvironment = hostingEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        #endregion


        // POST: api/workorder/saveupdate
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdate([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam  = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr   = data[1].ToString();
                string JsonData_Skill  = data[2].ToString();
                string JsonData_Resp   = data[3].ToString();
                string JsonData_Req    = data[4].ToString();
                string JsonData_Exp    = data[5].ToString();
                string JsonData_Ot_Req = data[6].ToString();
                string JsonData_Benf   = data[7].ToString();
   
                if (!string.IsNullOrEmpty(JsonData_Mstr) )
                {
                    resdata = await _manager.SaveUpdate(JsonData_Mstr, JsonData_Skill, JsonData_Resp, JsonData_Req, JsonData_Exp, JsonData_Ot_Req, JsonData_Benf, cparam);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result = new
            {
                resdata
            };
        }


        // GET: api/jobpost/getbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbylist([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetWithList(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

  /*      // GET: api/jobpost/getbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getlocationlist()
        {
            object result = null; object resdata = null;
            try
            {
               // dynamic data = JsonConvert.DeserializeObject(param);
               // vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetLocationList();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }*/

        //Job Post  Get by id 
        // GET: api/jobPost/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getlocationlist([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
               // dynamic data = JsonConvert.DeserializeObject(param);
               // vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetLocationList();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }





        // GET: api/jobpost/getbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbypages([FromQuery] string param)
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


        //Job Post  Get by id 
        // GET: api/jobPost/getbyid
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


        // GET: api/jobpost/reqgetbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> reqgetbypages([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetReqByPage(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/jobPost/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> reqgetbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetReqByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }





        //------------------BUSINESS PART START FROM HERE-----------------------------------------

        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> businesstypesaveupdate([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                if (!string.IsNullOrEmpty(JsonData_Mstr))
                {
                    resdata = await _manager.BusinessTypeSaveUpdate(JsonData_Mstr, cparam);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result = new
            {
                resdata
            };
        }


        // GET: api/jobpost/getbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> businessgetbypages([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.BusinessGetWithPagination(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }



        // GET: api/jobPost/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> businessgetbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.BusinessGetByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/jobPost/getallcompantfronjob
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallcompantfromjob([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getDistinctCompanyJob();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/jobPost/getallcompantfronjob
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallDepartmentFromJob([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getDistinctDepartmentJob();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        // GET: api/jobPost/getallcompantfronjob
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallDesignationFromJob([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getDistinctDesignationJob();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }












    }


}
