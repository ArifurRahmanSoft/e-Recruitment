using DataFactories.BaseFactory;
//using DataModel.EntityModels.OraModel;
using DataModel.ViewModels;
using DataUtility;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Drawing;
using DataModel.JobEntityModel.JobOraModelTest;
using static System.Net.WebRequestMethods;

namespace DataFactories.DBService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        ModelContext _ctxOr = null;

        public EmailService(IConfiguration config)
        {
            _config = config;
            
        }


 




        public async Task<string> FindEamil(string toEmail)
        {
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    var email = await _ctxOr.TSysUsers
                        .Where(u => u.Email.ToLower() == toEmail.ToLower())
                        .Select(u => u.Email)
                        .FirstOrDefaultAsync();

                    return email;  // returns the matched email or null
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return null;
            }
        }


        public async Task<bool> UpdateOtpForUser(string email, string otp)
        {
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    var user = await _ctxOr.TSysUsers
                                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

                    if (user == null)
                        return false;

                    user.Otp = otp;
                    user.Expireotp = DateTime.UtcNow.AddMinutes(12); 

                    await _ctxOr.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false;
            }
        }


        //UPDATE MAIL CANDIDATE TABLE BASED ON MAIL

        public async Task<bool> UpdateCandidateByMailType(string applicationOID, string mailType)
        {
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    var user = await _ctxOr.TJobApplicantMainMasters
                                .FirstOrDefaultAsync(u => u.Oid == applicationOID);

                    if (user == null)
                        return false;
                    if(mailType== "offerLatter")
                    {
                        user.Isselected = "1";
                    }
                    if (mailType == "isWritten")
                    {
                        user.Iswritten = "1";
                    }
                    if (mailType == "isViva")
                    {
                        user.Isviva = "1";
                    }


                    await _ctxOr.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false;
            }
        }
        //end 

   





        //FOR OTP CHECK HERE
/*        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body,string otp)
        {
            string foundEmail = await FindEamil(toEmail);

            if (string.IsNullOrEmpty(foundEmail) || !string.Equals(foundEmail, toEmail, StringComparison.OrdinalIgnoreCase))
            {
               
                return false;
            }

            try
            {
                var smtpClient = new SmtpClient(_config["EmailSettings:SmtpServer"])
                {
                    Port = int.Parse(_config["EmailSettings:Port"]),
                    Credentials = new NetworkCredential(
                        _config["EmailSettings:Username"],
                        _config["EmailSettings:Password"]),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_config["EmailSettings:From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                var updated = await UpdateOtpForUser(toEmail, otp);
                return updated; 
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false; // sending failed
            }
        }*/


        //USING CAREER MAIL 
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, string otp)
        {
            string foundEmail = await FindEamil(toEmail);

            if (string.IsNullOrEmpty(foundEmail) ||
                !string.Equals(foundEmail, toEmail, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            try
            {
                var host = _config["CityEmailConfig:EmailSenderHost"];
                var port = int.Parse(_config["CityEmailConfig:EmailSenderPort"]);
                var username = _config["CityEmailConfig:EmailSenderId"];
                var password = _config["CityEmailConfig:EmailSenderPassword"];
                var enableSsl = bool.Parse(_config["CityEmailConfig:EmailSenderEnableSsl"]);
                var senderTitle = _config["CityEmailConfig:SenderTitle"];

                using (var smtpClient = new SmtpClient(host))
                {
                    smtpClient.Port = port;
                    smtpClient.Credentials = new NetworkCredential(username, password);
                    smtpClient.EnableSsl = enableSsl;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(username, senderTitle), // Sender email + title
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(toEmail);

                    await smtpClient.SendMailAsync(mailMessage);

                    // Update OTP after email sent
                    var updated = await UpdateOtpForUser(toEmail, otp);
                    return updated;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false;
            }
        }



        public async Task<bool> SendEmailToCandidate(string toEmail, string subject, string body,string mailType,string applicationOID)
        {
            string foundEmail = await FindEamil(toEmail);

            if (string.IsNullOrEmpty(foundEmail) || !string.Equals(foundEmail, toEmail, StringComparison.OrdinalIgnoreCase))
            {

                return false;
            }

            try
            {
                var smtpClient = new SmtpClient(_config["EmailSettings:SmtpServer"])
                {
                    Port = int.Parse(_config["EmailSettings:Port"]),
                    Credentials = new NetworkCredential(
                        _config["EmailSettings:Username"],
                        _config["EmailSettings:Password"]),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_config["EmailSettings:From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                var updated = await UpdateCandidateByMailType(applicationOID,mailType);
                return updated;
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false; // sending failed
            }
        }



        public async Task<bool> verifyotp(string otp, string email)
        {
            try
            {
                using (_ctxOr = new ModelContext())
                {
                    var user = await _ctxOr.TSysUsers
                        .Where(u => u.Email == email && u.Otp == otp)
                        .FirstOrDefaultAsync();

                    return user != null;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false;
            }
        }






        /* public async Task<bool> updatepassword(string email, string password,string otp)
         {
             try
             {
                 using (_ctxOr = new ModelContext())
                 {
                     var user = await _ctxOr.TSysUsers
                                 .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

                     if (user == null)
                         return false;

                     user.Password = password;
                     await _ctxOr.SaveChangesAsync();
                     return true;
                 }
             }
             catch (Exception ex)
             {
                 Logs.Bug(ex);
                 return false;
             }
         }*/

        public async Task<bool> updatepassword(string email, string password, string otp)
        {
            try
            {
                using (_ctxOr = new ModelContext())
                {
                   
                    var user = await _ctxOr.TSysUsers
                        .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Otp == otp);

                    if (user == null)
                        return false; 
                    user.Password = password;
                    user.Otp = null;

                    await _ctxOr.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                return false;
            }
        }











    }

}
