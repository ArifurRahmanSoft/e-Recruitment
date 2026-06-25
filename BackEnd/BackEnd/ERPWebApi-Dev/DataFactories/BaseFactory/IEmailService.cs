//using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataFactories.BaseFactory
{
    public interface IEmailService
    {
        //Task SendEmailAsync(string toEmail, string subject, string body);
        Task<bool> SendEmailAsync(string toEmail, string subject, string body ,string otp);
        Task<bool> verifyotp(string otp,string email);
        Task<bool> updatepassword(string email, string password,string otp);
        Task<bool> SendEmailToCandidate(string toEmail, string subject, string body,string mailType,string applicationOID);
    }

}
