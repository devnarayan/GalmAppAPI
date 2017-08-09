using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace GalmApp.Api.Services
{
    public class SMTPService
    {
        SmtpClient smtp;
        public SMTPService()
        {
            smtp = new SmtpClient();
            smtp.Host = "smtp.sparkpostmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(
               "SMTP_Injection", "b2dbc63c072153f65b0a34113ec8f033d2cbb161");

        }
        public bool SendResetCodeMessage(string email, string resetCode)
        {
            // You will need an API Key with 'Send via SMTP' permissions.
            // Create one here: https://app.sparkpost.com/account/credentials
            // sparkpostbox.com is a sending domain used for testing
            // purposes and is limited to 50 messages per account.
            // Visit https://app.sparkpost.com/account/sending-domains
            // to register and verify your own sending domain.
            try
            {
                MailAddress from = new MailAddress("hello@mail.teetra.com");
                MailAddress to = new MailAddress(email);
                MailMessage mail = new MailMessage(from, to);
                mail.IsBodyHtml = true;

                mail.Subject = "Reset password : Teetra";
                mail.Body = "Hello! <br/> Your password reset code is : " + resetCode;
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}