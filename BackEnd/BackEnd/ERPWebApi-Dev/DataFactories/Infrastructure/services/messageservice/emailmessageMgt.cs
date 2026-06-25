using DataModel.ViewModels;
using DataModel.ViewModels.ERPViewModel.Common;
using DataUtility;
using Microsoft.Extensions.Configuration;
//using Syncfusion.HtmlConverter;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Graphics;
//using Syncfusion.Pdf.HtmlToPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFactory.Infrastructure.services.messageservice
{
    public class emailmessageMgt
    {
        #region global variables
        private static vmEmailConfig _objEmail = null;
        private static IConfiguration _configuration = null;
        #endregion

        #region contructor

        public emailmessageMgt()
        {

        }

        public emailmessageMgt(IConfiguration iConfig, string WebRootPath)
        {
            _configuration = iConfig;
            _objEmail = new vmEmailConfig
            {
                 EmailSenderId = _configuration.GetSection("CityEmailConfig").GetSection("EmailSenderId").Value, //it will be start 
                 EmailSenderPassword = _configuration.GetSection("CityEmailConfig").GetSection("EmailSenderPassword").Value,
                 EmailSenderHost = _configuration.GetSection("CityEmailConfig").GetSection("EmailSenderHost").Value,
                 EmailSenderPort = Convert.ToInt32(_configuration.GetSection("CityEmailConfig").GetSection("EmailSenderPort").Value),
                 EmailSenderEnableSsl = Convert.ToBoolean(_configuration.GetSection("CityEmailConfig").GetSection("EmailSenderEnableSsl").Value),
                 RootPath = WebRootPath





                /*EmailSenderId = "arif.cgit@gmail.com",
                EmailSenderPassword = "torq kkzs rrma umgx",
                EmailSenderHost = "smtp.gmail.com",
                EmailSenderPort = 587,
                EmailSenderEnableSsl = true, // Since it's Gmail
                RootPath = WebRootPath*/
            };
        }

        #endregion

        #region common function
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                var isvalid = addr.Address == email;
                return isvalid;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Service Request Mail
        public async Task<object> ServiceRequestMail(vmServiceRequest model, vmSrvcReqMail _jMail)
        {
            object result = null, resstate = false; string message = string.Empty; int results = 0;
            try
            {
                if (IsValidEmail(_jMail.MailTo) && IsValidEmail(_jMail.MailFrom))
                {
                    vmCmnParameters param = new vmCmnParameters();                    
                    string emailTo = _jMail.MailTo;
                    string EmailFormatPath = _objEmail.RootPath + "/emailTemplates/CityErequrement.html";
                    string emailBody = string.Empty;

                    if (File.Exists(EmailFormatPath))
                    {
                        emailBody = File.ReadAllText(EmailFormatPath);

                        //Replace
                        emailBody = emailBody.Replace("#NameTo#", _jMail.NameTo);
                        emailBody = emailBody.Replace("#Message1#", _jMail.Message1);
                        /*  emailBody = emailBody.Replace("#ServiceID#", model.TRNNO);
                          emailBody = emailBody.Replace("#TransactionNo#", model.TRANSACTIONNO);
                          emailBody = emailBody.Replace("#ServiceType#", model.TYPENAME);
                          emailBody = emailBody.Replace("#Details#", model.FIELDS);
                          emailBody = emailBody.Replace("#Remarks#", model.NARRATION);*/
                        emailBody = emailBody.Replace("#jobTitle#", _jMail.jobTitle);
                        emailBody = emailBody.Replace("#Company#", _jMail.Company);

                        emailBody = emailBody.Replace("#examDate#", _jMail.examDate); 
                        emailBody = emailBody.Replace("#examHour#", _jMail.examHour); 

                        emailBody = emailBody.Replace("#designation#", _jMail.Designation); 
                        emailBody = emailBody.Replace("#TransactionNo#", "model.TRANSACTIONNO");
                        emailBody = emailBody.Replace("#ServiceType#", "model.TYPENAME");
                        emailBody = emailBody.Replace("#Details#", "model.FIELDS");
                        emailBody = emailBody.Replace("#Remarks#", "model.NARRATION");
                        emailBody = emailBody.Replace("#CreateBy#", _jMail.CreateBy);
                        emailBody = emailBody.Replace("#CreateOn#", _jMail.CreateOn);
                        emailBody = emailBody.Replace("#Status#", _jMail.Status);
                        emailBody = emailBody.Replace("#ResponseBy#", _jMail.ResponseBy);
                        emailBody = emailBody.Replace("#ResponseOn#", _jMail.ResponseOn);

                        results = await new EmailSender().GeneralMail(_objEmail, _jMail.MailFrom, _jMail.MailTo, _jMail.MailCC, _jMail.Title, _jMail.Subject, emailBody);
                        message = results == 0 ? MessageConstants.MailWarning : MessageConstants.MailSuccess;
                        resstate = results == 0 ? MessageConstants.ErrorState : MessageConstants.SuccessState;
                    }
                    else
                    {
                        message = MessageConstants.MailTemplate;
                        resstate = MessageConstants.ErrorState;
                    }
                }
                else
                {
                    message = MessageConstants.InvalidMail;
                    resstate = MessageConstants.ErrorState;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                message = MessageConstants.MailWarning;
                resstate = MessageConstants.ErrorState;
            }

            return result = new
            {
                message,
                resstate
            };
        }
        #endregion

    }
}

