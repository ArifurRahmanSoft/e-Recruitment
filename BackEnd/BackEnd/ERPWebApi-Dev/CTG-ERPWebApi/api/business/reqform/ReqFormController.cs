using DataFactories.Infrastructure.business.businessconfigure;
using DataFactories.Infrastructure.business.workorder;
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
using DataFactories.Infrastructure.business.reqform;
using DataModel.JobEntityModel.JobOraModelTest;
using System.DirectoryServices.Protocols;
using System.IO;
using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.IdentityModel.Tokens;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Ocsp;
//using System.Net.Mail;
using MimeKit;
using MailKit.Security;
using DataUtility;
using Microsoft.VisualBasic;
using NuGet.ProjectModel;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace CTG_ERPWebApi.api.business.reqform
{
    // [Route("api/[controller]")]
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class ReqFormController : ControllerBase
    {




        private IWebHostEnvironment _hostingEnvironment;

        #region Variable Declaration & Initialization
        private ReqFormMgt _manager = null;
        private BusinessSetupMgt _srvManager = null;
        private ModelContext _ctxOr = null;
        #endregion

        #region Constructor
        public ReqFormController(IWebHostEnvironment hostingEnvironment)
        {

            _manager = new ReqFormMgt();
            _srvManager = new BusinessSetupMgt();
            _hostingEnvironment = hostingEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _ctxOr = new ModelContext();
        }
        #endregion

        //GET  USER DETAILS BY ID
        // GET BY ID: api/reqform/getuserdetialsbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getuserdetialsbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetUserDetailsByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET BY ID: api/reqform/getapplicantprofileid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapplicantprofileid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetApplicantProfileByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        //START FROM HERE -------------------------------ADDRESS-----------------------------------
        /*      [Route("~/api/GetDistrictListById")]
              [HttpGet]
              public dynamic GetDistrictList(string Name)
              {
                  //AddressRepository bs = new AddressRepository();
                  var list = _manager.GetDistrict(Name);
                  return list;
              }


              //GET DISTRICT LIST USING STORE PROCDURE
              [Route("~/api/GetThanaListById")]
              [HttpGet]
              public dynamic GetThanaList(string Name)
              {
                  //AddressRepository bs = new AddressRepository();
                  var list = _manager.GetThanaList(Name);
                  return list;
              }*/



        //------------------------------------eND--------------------------------------------


        // GET BY ID: api/reqform/getdistrictbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getdistrictbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetDistrictByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET BY ID: api/reqform/getDistrictbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getthanabyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetThanaByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        //GET ALL DATA BY USERID
        // GET BY ID: api/reqform/getbypagesbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbypagesbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetWithPaginationById(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }



        // POST: api/reqform/saveupdate
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdate([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                string JsonData_acQlf = data[2].ToString();
                string JsonData_experience = data[3].ToString();
                string JsonData_profCirtificate = data[4].ToString();
                string JsonData_Training = data[5].ToString();
                string JsonData_Refernce = data[6].ToString();

                if (!string.IsNullOrEmpty(JsonData_Mstr) && !string.IsNullOrEmpty(JsonData_acQlf))
                {
                    resdata = await _manager.SaveUpdate(JsonData_Mstr, JsonData_acQlf, JsonData_experience, JsonData_profCirtificate, JsonData_Training, JsonData_Refernce, cparam);
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


        // POST: api/reqform/saveupdate
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> SaveUpdateMessage([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                if (!string.IsNullOrEmpty(JsonData_Mstr))
                {
                    resdata = await _manager.SaveUpdateMessage(JsonData_Mstr, cparam);
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

        // POST: api/reqform/saveupdate
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> SaveUpdateJoiningInfo([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                if (!string.IsNullOrEmpty(JsonData_Mstr))
                {
                    resdata = await _manager.saveUpdateJoiningApplicant(JsonData_Mstr, cparam);
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

        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> SaveUpdateVerifyInfo([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                if (!string.IsNullOrEmpty(JsonData_Mstr))
                {
                    resdata = await _manager.saveUpdateVerifyApplicant(JsonData_Mstr, cparam);
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

        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> SaveUpdateApproveInfo([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                if (!string.IsNullOrEmpty(JsonData_Mstr))
                {
                    resdata = await _manager.saveUpdateApproveApplication(JsonData_Mstr, cparam);
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

        
        //JOB APPLY WHEN EXIST PROFILE
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> applicantjobapply([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                string test = null;
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.saveApplicantJobApply(cparam);
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





        //FOR IMAGE UPLOAD AS BLOB
        [HttpPost("[action]")]
        public async Task<IActionResult> dbsinleuploadfileBlob(IFormFileCollection fileCollection)
        {
            ApiResponse response = new ApiResponse();
            int passcount = 0; int errorCount = 0;
            List<decimal> documentIds = new List<decimal>();
            try
            {
                foreach (var file in fileCollection)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        TJobApplicantDocument document = new TJobApplicantDocument
                        {
                            File = stream.ToArray()
                        };
                        this._ctxOr.TJobApplicantDocuments.Add(document);
                        await this._ctxOr.SaveChangesAsync();

                        // After SaveChangesAsync, the Documentid will be populated
                        documentIds.Add(document.Documentid);
                        passcount++;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCount++;
                response.Message = ex.Message;
            }
            response.ResponseCode = 200;
            response.Data = documentIds;
            response.Result = passcount + " File Upload & " + errorCount + "files failed";
            return Ok(response);
        }


        //FOR IMAGE PATH UPLOAD------------------------------------------------------
        [HttpPost("[action]")]
        public async Task<IActionResult> dbsinleuploadfile(IFormFileCollection fileCollection, [FromForm] string referenceId)
        {
            ApiResponse response = new ApiResponse();
            int passcount = 0;
            int errorCount = 0;
            List<decimal> documentIds = new List<decimal>();
            /*    string uploadFolder = "https://app.citygroupbd.com/uploadFiles/DMS/EREQ/";  // Define the folder to store the files. Make sure the folder exists and has the correct permissions.
                string basePath = "E:/DMS/EREQ/";
                string newPath = uploadFolder;*/

            string basePath = "E:/DMS/EREQ/";
            string newPaths = basePath;
            string _newPath = newPaths.ToString().Replace(@"\", @"/");
            string refId = referenceId.ToString();

            //Virtual Directory
            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.64.72";
            string vPort = StaticInfos.IsLive ? "/EREQ/" : "84";
            string vPath = StaticInfos.IsLive ? vIpAdd + vPort : vIpAdd + ":" + vPort;


            try
            {
                if (!Directory.Exists(_newPath))
                {
                    Directory.CreateDirectory(_newPath);
                }
                foreach (var file in fileCollection)
                {
                    if (file != null && file.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;  // Generate a unique file name
                        string filePath = Path.Combine(_newPath, uniqueFileName);  // Combine folder path and file name
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        // Save the file path to the database
                        TJobApplicantDocument document = new TJobApplicantDocument
                        {

                            Documentfullpath = filePath,
                            Documentname = file.Name,
                            Documenttype = file.ContentType,
                            Filename=file.FileName,//add later
                            Referenceid= refId,//add later
                            Documentsize = file.Length,
                            Basepath = basePath,
                            Documentpath = _newPath,
                            Virtualpath = vPath + uniqueFileName
                        };




                        this._ctxOr.TJobApplicantDocuments.Add(document);
                        await this._ctxOr.SaveChangesAsync();

                        // After SaveChangesAsync, the DocumentId will be populated
                        documentIds.Add(document.Documentid); // Add the saved file path to the list
                        passcount++;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCount++;
                response.Message = ex.Message;
            }

            response.ResponseCode = 200;
            response.Data = documentIds;  // Return the file paths as response data
            response.Result = passcount + " File(s) Uploaded & " + errorCount + " File(s) Failed";
            return Ok(response);
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFile(IFormFileCollection fileCollection)
        {
            ApiResponse response = new ApiResponse();
            int passcount = 0;
            int errorCount = 0;
            List<decimal> documentIds = new List<decimal>();
            /*    string uploadFolder = "https://app.citygroupbd.com/uploadFiles/DMS/EREQ/";  // Define the folder to store the files. Make sure the folder exists and has the correct permissions.
                string basePath = "E:/DMS/EREQ/";
                string newPath = uploadFolder;*/

            string basePath = "E:/DMS/EREQ/";
            string newPaths = basePath;
            string _newPath = newPaths.ToString().Replace(@"\", @"/");

            //Virtual Directory
            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.64.72";
            string vPort = StaticInfos.IsLive ? "/EREQ/" : "84";
            string vPath = StaticInfos.IsLive ? vIpAdd + vPort : vIpAdd + ":" + vPort;


            try
            {
                if (!Directory.Exists(_newPath))
                {
                    Directory.CreateDirectory(_newPath);
                }
                foreach (var file in fileCollection)
                {
                    if (file != null && file.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;  // Generate a unique file name
                        string filePath = Path.Combine(_newPath, uniqueFileName);  // Combine folder path and file name
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        // Save the file path to the database
                        TJobApplicantDocument document = new TJobApplicantDocument
                        {

                            Documentfullpath = filePath,
                            Documentname = file.Name,
                            Documenttype = file.ContentType,
                            Documentsize = file.Length,
                            Basepath = basePath,
                            Documentpath = _newPath,
                            Virtualpath = vPath + uniqueFileName
                        };




                        this._ctxOr.TJobApplicantDocuments.Add(document);
                        await this._ctxOr.SaveChangesAsync();

                        // After SaveChangesAsync, the DocumentId will be populated
                        documentIds.Add(document.Documentid); // Add the saved file path to the list
                        passcount++;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCount++;
                response.Message = ex.Message;
            }

            response.ResponseCode = 200;
            response.Data = documentIds;  // Return the file paths as response data
            response.Result = passcount + " File(s) Uploaded & " + errorCount + " File(s) Failed";
            return Ok(response);
        }



        //FOR IMAGE/ FILE UPDATE 
        /*   [HttpPost("updateFile/{id}")]
           public async Task<IActionResult> UpdateFile(decimal id, IFormFile newFile)
           {
               List<decimal> documentIds = new List<decimal>();
               ApiResponse response = new ApiResponse();
               string uploadFolder = "https://app.citygroupbd.com/uploadFiles/EREQ";

               try
               {
                   var existingDoc = await _ctxOr.TJobApplicantDocuments.FindAsync(id);
                   if (existingDoc == null)
                   {
                       return NotFound("Document not found.");
                   }

                   // Delete old file from disk
                   if (System.IO.File.Exists(existingDoc.Basepath))
                   {
                       System.IO.File.Delete(existingDoc.Basepath);
                   }

                   // Save new file
                   string uniqueFileName = Guid.NewGuid().ToString() + "_" + newFile.FileName;
                   string newFilePath = Path.Combine(uploadFolder, uniqueFileName);

                   using (var stream = new FileStream(newFilePath, FileMode.Create))
                   {
                       await newFile.CopyToAsync(stream);
                   }

                   // Update database record
                   existingDoc.Basepath = newFilePath;
                   existingDoc.Documentname = newFile.FileName;
                   existingDoc.Documenttype = newFile.ContentType;
                   existingDoc.Updateon = DateTime.Now;

                   _ctxOr.TJobApplicantDocuments.Update(existingDoc);
                   await _ctxOr.SaveChangesAsync();
                   documentIds.Add(existingDoc.Documentid);
                   response.ResponseCode = 200;
                   response.Result = "File updated successfully.";
                   //response.Data = documentIds.Documentid;
               }
               catch (Exception ex)
               {
                   response.ResponseCode = 500;
                   response.Message = ex.Message;
               }

               return Ok(response);
           }

   */

        /*   [HttpGet("getImage/{docId}")]
           public IActionResult GetImage(string docId)
           {
               try
               {
                   // Retrieve the file path from the database using the documentId
                   var document = _ctxOr.TJobApplicantDocuments.FirstOrDefault(d => d.Documentid.ToString() == docId);
                   //if (document == null || string.IsNullOrEmpty(document.Documentfullpath))
                   //{
                   //    return NotFound("Image not found.");
                   //}

                   // Check if the file exists
                   if (!System.IO.File.Exists(document.Virtualpath))
                   {
                       return NotFound("File not found.");
                   }

                   // Get the file's content type
                   string contentType = "application/octet-stream";
                   var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
                   if (provider.TryGetContentType(document.Virtualpath, out var detectedType))
                   {
                       contentType = detectedType;
                   }

                   // Return the file as a response
                   var fileBytes = System.IO.File.ReadAllBytes(document.Virtualpath);

                   return File(fileBytes, contentType);
               }
               catch (Exception ex)
               {
                   return StatusCode(500, $"Internal server error: {ex.Message}");
               }
           }*/


        [HttpGet("getImage/{docId}")]
        public async Task<IActionResult> GetImage(string docId)
        {
            try
            {
                // Retrieve the file path from the database using the documentId
                var document = _ctxOr.TJobApplicantDocuments.FirstOrDefault(d => d.Documentid.ToString() == docId);

                if (document == null || string.IsNullOrEmpty(document.Virtualpath))
                {
                    return NotFound("Document not found.");
                }

                // Use HttpClient to download file from URL
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(document.Virtualpath);

                    if (!response.IsSuccessStatusCode)
                    {
                        return NotFound("File not found at remote path.");
                    }

                    byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();

                    // Detect the content type based on file extension
                    string contentType = "application/octet-stream";
                    var provider = new FileExtensionContentTypeProvider();
                    if (provider.TryGetContentType(document.Virtualpath, out var detectedType))
                    {
                        contentType = detectedType;
                    }

                    return File(fileBytes, contentType);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        // GET: api/reqform/getapplicantbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapplicantbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                //cmnParam
                dynamic data = JsonConvert.DeserializeObject(param);
                var cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetApplcntByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }



        // GET: api/reqform/getcandidatedetailsbyid//FOR INDIVIDUAL PROFILE
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getcandidatedetailsbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.getcandiDatedetailsByid(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        //FOR EVERY JOB APPLY
        // GET: api/reqform/getcandidatedetailsbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getapplicationdetailbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.getApplicationDetalByid(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }






        // GET: api/workorder/getregularreport
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> getregularreport([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmReportModel rptm = new vmReportModel();
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[2].ToString());
                dynamic cparam = JsonConvert.DeserializeObject(data[0].ToString());
                rptm.ReportPath = _hostingEnvironment.WebRootPath + cparam.reportPath;
                rptm.RenderType = cparam.reportType;
                resdata = await _manager.GetRegularReport(rptm, cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> getapplicatntreport([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmReportModel rptm = new vmReportModel();
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[2].ToString());
                dynamic cparam = JsonConvert.DeserializeObject(data[0].ToString());
                rptm.ReportPath = _hostingEnvironment.WebRootPath + cparam.reportPath;
                rptm.RenderType = cparam.reportType;
                resdata = await _manager.GetApplicantReport(rptm, cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        //GET JOB ID LIST FORM JOB POST MASTER
        // GET: api/reqform/getJobIdByMail
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getJobIdByMail([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.getJobIdByMail(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }



        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] vmEmailModel email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "arifur.rahman@citygroupbd.com"));
            message.To.Add(new MailboxAddress("", email.To));
            message.Subject = email.Subject;

            message.Body = new TextPart("html")
            {
                Text = email.Body
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {

                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("arifur.rahman@citygroupbd.com", "Arif8427");
                    client.Send(message);
                    client.Disconnect(true);

                    return Ok("Email sent successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest("Failed to send email: " + ex.Message);
                }
            }
        }




       
        [HttpGet("[action]")]
        public async Task<IActionResult> removedocument([FromQuery] string param)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                bool  isRemove = await _manager.RemoveDocument(cmnParam.strId, cmnParam.strId2);
            }
            catch (Exception ex) {   }
            return Ok(true);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> dbsinleuploadfiles(
        IFormFileCollection fileCollection,[FromForm] string referenceId, [FromForm] string type,[FromForm] List<string> docId, [FromForm] List<string> fileType)
        {
            ApiResponse response = new ApiResponse();
            int passcount = 0;
            int errorCount = 0;
            List<decimal> documentIds = new List<decimal>();

            string basePath = "E:/DMS/EREQ/";
            string _newPath = basePath.Replace(@"\", @"/");
            string refId = referenceId;

            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.64.72";
            string vPort = StaticInfos.IsLive ? "/EREQ/" : "84";
            string vPath = StaticInfos.IsLive ? vIpAdd + vPort : vIpAdd + ":" + vPort;

            if (type != "master")
            {
                var details = await GetQuery(type, referenceId).ToListAsync();
                try
                {
                    if (!Directory.Exists(_newPath))
                    {
                        Directory.CreateDirectory(_newPath);
                    }

                    for (int i = 0; i < fileCollection.Count; i++)
                    {
                        var file = fileCollection[i];
                        string currentDocId = docId.Count > i ? docId[i] : null; // match docId by index
                        string currentFileType = fileType.Count > i ? fileType[i] : null;
                        var matchDetailData = details.FirstOrDefault(x => x.DocName == fileType[i]);

                        if (file != null && file.Length > 0)
                        {
                            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                            string filePath = Path.Combine(_newPath, uniqueFileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            if (string.IsNullOrWhiteSpace(currentDocId) || currentDocId.Equals("null", StringComparison.OrdinalIgnoreCase) || currentDocId.Equals("undefined", StringComparison.OrdinalIgnoreCase))
                            {
                                // INSERT new record
                                var document = new TJobApplicantDocument
                                {
                                    Documentfullpath = filePath,
                                    Documentname = uniqueFileName,//file.Name, // original name
                                    Documenttype = file.ContentType,
                                    Filename = currentFileType,
                                    Referenceid = refId,
                                    Documentsize = file.Length,
                                    Basepath = basePath,
                                    Documentpath = _newPath,
                                    Virtualpath = vPath + uniqueFileName,
                                    Tabletype = type,
                                    RefRowid= matchDetailData.DetailsOid
                                };

                                this._ctxOr.TJobApplicantDocuments.Add(document);
                                await this._ctxOr.SaveChangesAsync();

                                documentIds.Add(document.Documentid);
                            }
                            else
                            {
                                // UPDATE existing record
                                if (decimal.TryParse(currentDocId, out var docIdDecimal))
                                {
                                    var existingDoc = await this._ctxOr.TJobApplicantDocuments
                                        .FirstOrDefaultAsync(d => d.Documentid == docIdDecimal);

                                    if (existingDoc != null)
                                    {

                                        //start delete
                                        if (!string.IsNullOrEmpty(existingDoc.Virtualpath) && System.IO.File.Exists(existingDoc.Virtualpath))
                                        {
                                            try
                                            {
                                                System.IO.File.Delete(existingDoc.Virtualpath);//Virtualpath Documentfullpath
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine($"Failed to delete old file: {ex.Message}");
                                            }
                                        }
                                        //end delete 

                                        existingDoc.Documentfullpath = filePath;
                                        existingDoc.Documentname = uniqueFileName;// file.Name; 
                                        existingDoc.Documenttype = file.ContentType;
                                        existingDoc.Filename = currentFileType;
                                        existingDoc.Referenceid = refId;
                                        existingDoc.Documentsize = file.Length;
                                        existingDoc.Basepath = basePath;
                                        existingDoc.Documentpath = _newPath;
                                        existingDoc.Virtualpath = vPath + uniqueFileName;
                                        existingDoc.Tabletype = type;



                                        this._ctxOr.TJobApplicantDocuments.Update(existingDoc);
                                        await this._ctxOr.SaveChangesAsync();

                                        documentIds.Add(existingDoc.Documentid);
                                    }
                                    else
                                    {
                                        errorCount++;
                                        continue;
                                    }
                                }
                                else
                                {
                                    errorCount++;
                                    continue;
                                }
                            }

                            passcount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorCount++;
                    response.Message = ex.Message;
                }

            }

            if (type == "master")
            { 

            try
            {
                if (!Directory.Exists(_newPath))
                {
                    Directory.CreateDirectory(_newPath);
                }

                for (int i = 0; i < fileCollection.Count; i++)
                {
                    var file = fileCollection[i];
                    string currentDocId = docId.Count > i ? docId[i] : null; // match docId by index
                    string currentFileType = fileType.Count > i ? fileType[i] : null;

                    if (file != null && file.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(_newPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        if (string.IsNullOrWhiteSpace(currentDocId) || currentDocId.Equals("null", StringComparison.OrdinalIgnoreCase) || currentDocId.Equals("undefined", StringComparison.OrdinalIgnoreCase))
                        {
                            // INSERT new record
                            var document = new TJobApplicantDocument
                            {
                                Documentfullpath = filePath,
                                Documentname = uniqueFileName,//file.Name, // original name
                                Documenttype = file.ContentType,
                                Filename = currentFileType,
                                Referenceid = refId,
                                Documentsize = file.Length,
                                Basepath = basePath,
                                Documentpath = _newPath,
                                Virtualpath = vPath + uniqueFileName,
                                Tabletype= type,
                                RefRowid = refId
                            };

                            this._ctxOr.TJobApplicantDocuments.Add(document);
                            await this._ctxOr.SaveChangesAsync();

                            documentIds.Add(document.Documentid);
                        }
                        else
                        {
                            // UPDATE existing record
                            if (decimal.TryParse(currentDocId, out var docIdDecimal))
                            {
                                var existingDoc = await this._ctxOr.TJobApplicantDocuments
                                    .FirstOrDefaultAsync(d => d.Documentid == docIdDecimal);

                                if (existingDoc != null)
                                {

                                    //start delete
                                    if (!string.IsNullOrEmpty(existingDoc.Virtualpath) && System.IO.File.Exists(existingDoc.Virtualpath))
                                    {
                                        try
                                        {
                                            System.IO.File.Delete(existingDoc.Virtualpath);//Virtualpath Documentfullpath
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Failed to delete old file: {ex.Message}");
                                        }
                                    }
                                    //end delete 

                                    existingDoc.Documentfullpath = filePath;
                                    existingDoc.Documentname = uniqueFileName;// file.Name; 
                                    existingDoc.Documenttype = file.ContentType;
                                    existingDoc.Filename = currentFileType;
                                    existingDoc.Referenceid = refId;
                                    existingDoc.Documentsize = file.Length;
                                    existingDoc.Basepath = basePath;
                                    existingDoc.Documentpath = _newPath;
                                    existingDoc.Virtualpath = vPath + uniqueFileName;
                                    existingDoc.Tabletype = type;
                                    existingDoc.RefRowid = refId;



                                    this._ctxOr.TJobApplicantDocuments.Update(existingDoc);
                                    await this._ctxOr.SaveChangesAsync();

                                    documentIds.Add(existingDoc.Documentid);
                                }
                                else
                                {
                                    errorCount++;
                                    continue;
                                }
                            }
                            else
                            {
                                errorCount++;
                                continue;
                            }
                        }

                        passcount++;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCount++;
                response.Message = ex.Message;
            }
            }
            response.ResponseCode = 200;
            response.Data = documentIds;
            response.Result = passcount + " File(s) Uploaded & " + errorCount + " File(s) Failed";
            return Ok(response);
        }



        private IQueryable<FileDetails> GetQuery(string type, string mstrOid)
        {
            switch (type)
            {
                case "academic":
                    return _ctxOr.TJobApplicantAcaQualifications
                        .Where(x => x.ApplicantOid == mstrOid && x.Isdelete == Extension.BoolVal(false))
                        .Select(x => new FileDetails { DetailsOid = x.Oid, DocName = x.Docname });

                case "experience":
                    return _ctxOr.TJobApplicantExperiences
                        .Where(x => x.ApplicantOid == mstrOid && x.Isdelete == Extension.BoolVal(false))
                        .Select(x => new FileDetails { DetailsOid = x.Oid, DocName = x.Docname });

                case "certificate":
                    return _ctxOr.TJobApplicantProfCertificates
                        .Where(x => x.ApplicantOid == mstrOid && x.Isdelete == Extension.BoolVal(false))
                        .Select(x => new FileDetails { DetailsOid = x.Oid, DocName = x.Docname });
                case "training":
                    return _ctxOr.TJobApplicantTrainings
                        .Where(x => x.ApplicantOid == mstrOid && x.Isdelete == Extension.BoolVal(false))
                        .Select(x => new FileDetails { DetailsOid = x.Oid, DocName = x.Docname });

                default:
                    return Enumerable.Empty<FileDetails>().AsQueryable();
            }
        }



        // POST: api/reqform/saveupdaterecapproval
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdaterecapproval([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                string JsonData_Mstr = data[1].ToString();
                string JsonData_ExamDetails = data[2].ToString();

                if (!string.IsNullOrEmpty(JsonData_Mstr) && !string.IsNullOrEmpty(JsonData_ExamDetails))
                {
                    resdata = await _manager.SaveUpdateRecruitmentApproval(JsonData_Mstr, JsonData_ExamDetails,  cparam);
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

        //--------------------------------------End----------------------------------------------------




        // POST: api/reqform/testsaveupdates
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> testsaveupdates([FromBody] object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                var bodyData = data;

                // ✅ HEADER DATA
                var userId = Request.Headers["userId"].ToString();
                var token = Request.Headers["token"].ToString();


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

















    }


}
