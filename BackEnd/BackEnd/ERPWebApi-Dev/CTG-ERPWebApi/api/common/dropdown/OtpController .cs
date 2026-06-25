using DataFactories.BaseFactory;
using DataFactories.Infrastructure.common.dropdown;
using DataModel.ViewModels;
using DataModel.ViewModels.ERPViewModel.Common;
using DataUtility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace CTG_ERPWebApi.api.common.dropdown
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class otpController : ControllerBase
    {
        #region Variable Declaration & Initialization
        //private EreqCommonDropdownMgt _manager = null;
        private readonly IEmailService _emailService;
        #endregion

        #region Constructor
        public otpController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        #endregion

       

        [HttpPost("sendotp")]
        public async Task<IActionResult> sendotp([FromBody] object[] data )
        {
            string emails = data[0].ToString();
            var email = JObject.Parse(emails)["email"].ToString();

            var otp = new Random().Next(100000, 999999).ToString();
            var subject = "Your OTP Code";
            var body = $"Your OTP is: {otp}";

            var sent = await _emailService.SendEmailAsync(email, subject, body, otp);

            if (sent)
            {
                return Ok(new { Message = "Check OTP In Your Email", Otp = otp }); 
            }
            else
            {
                return Ok(new { Message = "Email not found" });
            }
        }

        [HttpPost("sendmail")]
        public async Task<IActionResult> sendmail([FromBody] object[] data)
        {
            string datas = data[0].ToString();
            var email = JObject.Parse(datas)["toEmail"].ToString();
            var subject = JObject.Parse(datas)["subject"].ToString();
            var body = JObject.Parse(datas)["body"].ToString();
            var mailType = JObject.Parse(datas)["mailType"].ToString();
            var applicationOID = JObject.Parse(datas)["applicationOID"].ToString();

            // var otp = new Random().Next(100000, 999999).ToString();

            var sent = await _emailService.SendEmailToCandidate(email, subject, body, mailType, applicationOID);

            if (sent)
            {
                return Ok(new { Message = "Email Send Sucessfully",data="success" });
            }
            else
            {
                return Ok(new { Message = "Email not Faield" });
            }
        }


        [HttpPost("verifyotp")]
        public async Task<IActionResult> verifyotp([FromBody] object[] data)
        {
            string otps = data[0].ToString();
            var otp = JObject.Parse(otps)["otp"].ToString();
            var email = JObject.Parse(otps)["email"].ToString();
            var isValidOtp = await _emailService.verifyotp(otp,email);

            if (isValidOtp)
            {
                return Ok(new { Message = "OTP verified Successfully", Otp = otp });
            }
            else
            {
                //return BadRequest(new { Message = "OTP Verify Faield" });
                return Ok(new { Message = "OTP Verify Failed" });
            }
        }


        [HttpPost("updatepassword")]
        public async Task<IActionResult> updatepassword([FromBody] object[] data)
        {
            string datas = data[0].ToString();
            //string pass = data[1].ToString();
            var email = JObject.Parse(datas)["email"].ToString();
            var password = JObject.Parse(datas)["password"].ToString();
            var otp = JObject.Parse(datas)["otp"].ToString();
            var isSuccesfull = await _emailService.updatepassword(email,password,otp);

            if (isSuccesfull)
            {
                return Ok(new { Message = "Password changed successfully", Password = password });
            }
            else
            {
                return Ok(new { Message = "Password changed Not successfully" });
            }
        }




    }
}