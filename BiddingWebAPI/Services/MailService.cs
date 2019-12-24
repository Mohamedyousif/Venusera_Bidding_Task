using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BiddingWebAPI.Services
{
    public class MailService : IMailService
    {
        public void SendVerificationLinkEmail(string name,string emailId, string activationcode, string scheme, string host, string port)
        {
            var varifyUrl = scheme + "://" + host + ":" + port + "/ActiveUser.html?code=" + activationcode;
            var fromMail = new MailAddress("TaskVenusera@gmail.com", $"welcome {name}");
            var toMail = new MailAddress(emailId);
            var fronmEmailPassowrd = "LEVM1jJSdDkmPAqRLX4Nuseu";
            string subject = "Your account is successfull created";
            string body = "<br/><br/>We are excited to tell you that your account is" +
        " successfully created. Please click on the below link to verify your account" +
        " <br/><br/><a href='" + varifyUrl + "'>" + varifyUrl + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, fronmEmailPassowrd)

            };
            using (var message = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {

                }
                
        }
    }
}
