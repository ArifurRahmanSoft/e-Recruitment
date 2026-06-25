using DataModel.ViewModels;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace DataUtility
{
    public class EmailSender
    {

        public async Task<int> GeneralMailx(vmEmailConfig emConfig, string emailFrom, string emailTo, string emailCC, string title, string subject, string emailBody)
        {
            int result = 0;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(emailTo));
                    if (!string.IsNullOrEmpty(emailCC))
                    {
                        mail.CC.Add(new MailAddress(emailCC));
                    }

                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    //MailAddress mailaddress = new MailAddress(emailFrom, title);
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;

                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);
                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                result = 0;
            }
            return result;
        }


        public async Task<int> GeneralMail(vmEmailConfig emConfig,string emailFrom, string emailTo, 
            string emailCC, string title, string subject, string emailBody)
        {
            int result = 0;

            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(emConfig.EmailSenderId, title);
                    mail.To.Add(new MailAddress(emailTo));

                    if (!string.IsNullOrEmpty(emailCC))
                    {
                        mail.CC.Add(new MailAddress(emailCC));
                    }
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    using (var smtp = new SmtpClient(emConfig.EmailSenderHost, emConfig.EmailSenderPort))
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);
                        smtp.EnableSsl = emConfig.EmailSenderEnableSsl;

                       await smtp.SendMailAsync(mail);
                        result = 1;
                    }
                }
            }
            catch (SmtpFailedRecipientException sfx)
            {
                // Log specific recipient issue
                Logs.Bug(sfx);
                result = 0;
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
                result = 0;
            }

            return result;
        }



        public async Task<int> registrationemail(vmEmailConfig emConfig, string emailto, string title, string subject, string emailBody, int mailType, int platform)
        {
            int result = 0; string ccMail = string.Empty;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(emailto));
                    if (mailType < (int)StaticInfos.Mail.NoCCmail)
                    {
                        ccMail = mailType == (int)StaticInfos.Mail.UserRegistrationMail ? StaticInfos.SalesMailAccount : StaticInfos.CloudMailAccount;
                        mail.CC.Add(new MailAddress(ccMail));
                    }
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;



                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);

                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex.ToString());
                result = 0;
            }
            return result;
        }

        public async Task<int> registrationSalesEmail(vmEmailConfig emConfig, string emailto, string title, string subject, string emailBody, int mailType)
        {
            int result = 0; string ccMail = string.Empty;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    //mail.To.Add(new MailAddress(emailto));
                    if (mailType < (int)StaticInfos.Mail.NoCCmail)
                    {
                        ccMail = StaticInfos.SalesMailAccount;
                        mail.CC.Add(new MailAddress(ccMail));
                    }
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;

                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);

                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex.ToString());
                result = 0;
            }
            return result;
        }

        public async Task<int> registrationCloudEmail(vmEmailConfig emConfig, string emailto, string title, string subject, string emailBody, int mailType)
        {
            int result = 0; string ccMail = string.Empty;
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(emailto));
                    if (mailType < (int)StaticInfos.Mail.NoCCmail)
                    {
                        ccMail = StaticInfos.CloudMailAccount;
                        mail.CC.Add(new MailAddress(ccMail));
                    }
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;



                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);

                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }


            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex.ToString());
                result = 0;
            }
            return result;
        }

        public async Task<int> cloudUserBillingEmail(vmEmailConfig emConfig, string emailto, string title, string subject, string emailBody, int mailType, byte[] pdfFile,string fileName)
        {
            int result = 0; string ccMail = string.Empty;
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(emailto));
                    //if (mailType < (int)StaticInfos.Mail.NoCCmail)
                    //{
                    //    ccMail = StaticInfos.CloudMailAccount;
                    //    mail.CC.Add(new MailAddress(ccMail));
                    //}
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;
                   
                    mail.Attachments.Add(new Attachment(new MemoryStream(pdfFile), fileName+".pdf"));                  


                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);

                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }


            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex.ToString());
                result = 0;
            }
            return result;
        }

        public async Task<int> cloudUserOfferEmail(vmEmailConfig emConfig, string emailto, string title, string subject, string emailBody, int mailType, byte[] other, byte[] cloud)
        {
            int result = 0; string ccMail = string.Empty;
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(emailto));
                  
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;
                    if (other != null)
                    {
                        mail.Attachments.Add(new Attachment(new MemoryStream(other), "other.pdf"));
                    }
                    if (cloud != null)
                    {
                        mail.Attachments.Add(new Attachment(new MemoryStream(cloud), "cloud.pdf"));
                    }

                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);

                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }


            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex.ToString());
                result = 0;
            }
            return result;
        }

        #region Isp Crm Contact Us
        public async Task<int> IspCrmContactUsEmail(vmEmailConfig emConfig, string emailto, string title, string subject, string emailBody)
        {
            int result = 0; string ccMail = string.Empty;
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    //for (int i = 0; i < emailto.Count; i++)
                    //{
                    //    mail.To.Add(new MailAddress(emailto[i]));
                    //    //mail.Bcc.Add(new MailAddress(emailto[i]));
                    //}

                    var mailto = emailto.Split(',');
                    mail.To.Add(emailto);
                    mail.Subject = subject;
                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    MailAddress mailaddress = new MailAddress(emConfig.EmailSenderId, title);
                    mail.From = mailaddress;
                    


                    using (SmtpClient smtp = new SmtpClient(emConfig.EmailSenderHost))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emConfig.EmailSenderId, emConfig.EmailSenderPassword);

                        smtp.EnableSsl = Convert.ToBoolean(emConfig.EmailSenderEnableSsl);
                        await smtp.SendMailAsync(mail);

                        result = 1;
                    }
                }


            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex.ToString());
                result = 0;
            }
            return result;
        }
        #endregion
    }
}
