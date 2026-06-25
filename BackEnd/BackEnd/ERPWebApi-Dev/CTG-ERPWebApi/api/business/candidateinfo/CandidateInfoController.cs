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
using DataFactories.Infrastructure.business.candidateinfo;
using Microsoft.Extensions.Configuration;
using DataFactories.DBService;
using Newtonsoft.Json.Linq;
using Microsoft.Reporting.NETCore;
using System.Data;
using System.IO;
using Org.BouncyCastle.Utilities;

namespace CTG_ERPWebApi.api.business.candidateinfo
{
   // [Route("api/[controller]")]
[Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
[ApiController]
public class CandidateInfoController : ControllerBase
{
        private IWebHostEnvironment _hostingEnvironment;

        #region Variable Declaration & Initialization
        private CandidateInfoMgt _manager = null;
        private BusinessSetupMgt _srvManager = null;
        #endregion

    /*    #region Constructor
        public CandidateInfoController(IWebHostEnvironment hostingEnvironment)
        {
           
            _manager = new CandidateInfoMgt();
            _srvManager = new BusinessSetupMgt();
            _hostingEnvironment = hostingEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        #endregion*/
        #region Constructor
        public CandidateInfoController(IConfiguration iConfig, IWebHostEnvironment hostingEnvironment)
        {

            _manager = new CandidateInfoMgt(iConfig, hostingEnvironment.WebRootPath);
            _srvManager = new BusinessSetupMgt();
            _hostingEnvironment = hostingEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        #endregion

    




        // GET: api/candidateinfo/getbypages
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

        // GET: api/candidateinfo/getapplicationlstbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapplicationlstbypages([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetApplicationLstWithPagination(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/candidateinfo/getapplicationlstbypages
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getprofilelistbypages([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetProfileLstWithPagination(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }



        [HttpGet("[action]")]//BasicAuthorization check
        public async Task<object> getallapplication([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.getallapplication(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        //Job Post  Get by id 
        // GET: api/candidateinfo/getbyid
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


        //this is test case for of all the case 
        // GET api/report/jobpost?param=[{...}]
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<IActionResult> GetJobPostReport([FromQuery] string param)
        {
            try
            {
                // Deserialize same as your other controller to get vmCmnParameter
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = Newtonsoft.Json.JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());

                // Get DataTable from your service/manager
                DataTable dt = await _manager.GetByIDS(cmnParam); // <-- method you showed earlier

                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound("No data found for the provided ID.");
                }

                // Create LocalReport
                LocalReport report = new LocalReport();

                string rdlcPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "reportfile/business/test", "testReport.rdlc");
                string rdpath2 = _hostingEnvironment.WebRootPath + "testReport.rdlc";


                report.ReportPath = rdlcPath;
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(rds);

     
                string mimeType;
                string encoding;
                string fileNameExtension;
                Warning[] warnings;
                string[] streams;

                // call by position or by the correct name 'format'
                byte[] pdfBytes = report.Render(
            
                    format: "PDF",
                    deviceInfo: null,
                    mimeType: out mimeType,
                    encoding: out encoding,
                    fileNameExtension: out fileNameExtension,
                    warnings: out warnings,
                    streams: out streams
                );

                // Return PDF as FileResult
                 return File(pdfBytes, "application/pdf", "testReport.pdf");
         
       
            }
            catch (Exception ex)
            {
                // log ex
                return StatusCode(500, $"Error generating report: {ex.Message}");
            }
        }

        [HttpGet("GetPDF")]
        public async Task<IActionResult> GetPDF([FromQuery] string param)
        {
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(param);
            vmCmnParameter cmnParam = Newtonsoft.Json.JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            DataTable dt =await _manager.GetByIDS(cmnParam);

            LocalReport report = new LocalReport();

            string rdlcPath = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "reportfile/business/test", "testReport.rdlc");
            report.ReportPath = rdlcPath;

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            var result = report.Render("PDF");

            return File(result, "application/pdf", "testReport.pdf");
        }







        //END LIST OF THE TEST CASE FOR OF ALL THE CASE




        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getnotificationbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.getNotificationById(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }





   /*        [HttpPost("[action]")]
           public async Task<IActionResult> SendServiceRequestMail([FromBody] object[] pram)
           {
               try
               {
                   vmEmailDetailsModel cparam = JsonConvert.DeserializeObject<vmEmailDetailsModel>(pram[0].ToString());
                   var result = await _manager.MailingProcess(cparam);
                   return Ok(result);
               }
               catch (Exception ex)
               {
                   var errorResult = new
                   {
                       message = "Error: " + ex.Message,
                       resstate = false
                   };
                   return StatusCode(500, errorResult);
               }
           }*/



        [HttpPost("[action]")]
        public async Task<IActionResult> SendServiceRequestMail([FromBody] object[] pram)
        {
            try
            {
                string cparam = pram[0].ToString();
                //vmEmailDetailsModel cparam = JsonConvert.DeserializeObject<vmEmailDetailsModel>(pram[0].ToString());
                var result = await _manager.MailingProcess(cparam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResult = new
                {
                    message = "Error: " + ex.Message,
                    resstate = false
                };
                return StatusCode(500, errorResult);
            }
        }







        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getexaminarbypages([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetExaminarListByPages(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> geteallexaminardrpdwn()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetDrpdownAllExaminar();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> geteallemployeedrpdwn()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetDrpdownAllEmployee();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }
















    }


}
