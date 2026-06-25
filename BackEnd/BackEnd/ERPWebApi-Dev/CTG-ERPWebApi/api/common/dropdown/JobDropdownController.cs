using DataFactories.Infrastructure.common.dropdown;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CTG_ERPWebApi.api.common.dropdown
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class jobdropdownController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private JobCommonDropdownMgt _manager = null;
        #endregion

        #region Constructor
        public jobdropdownController()
        {
            _manager = new JobCommonDropdownMgt();
        }
        #endregion



        //------------------------------!!!!!START!!!!!!!------------------------------------------
        // GET: api/jobdropdown/getalldivision
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getalldivision()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllDivision();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }
        // GET: api/jobdropdown/get DISTRICT BY ID
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getalldistrictById(string id)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getallDistrictById(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        // GET: api/jobdropdown/get DISTRICT BY ID
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallthanaById(string id)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.getallthanaById(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

    


        // GET: api/jobdropdown/getallbrand
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallcompany()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllCompany();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/jobdropdown/getallbrand
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getalldepartment()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllDepartment();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/jobdropdown/getallbrand
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getalldesignation()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllDesignation();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        

   
        //---------------------------!!!!!END!!!!!--------------------------------------------------//



















    }
}