using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AgricultureManagementSystem.Public
{
    public class Common
    {
        public static bool SendMail(string smtpServer, int smtpPort, string password, string strFrom, string strTo, string strSubject, string strBody)
        {
            try
            {
                MailAddress mailFrom = new MailAddress(strFrom);
                MailAddress mailTo = new MailAddress(strTo);

                MailMessage mailMessage = new MailMessage(mailFrom, mailTo)
                {
                    Subject = strSubject,
                    Body = strBody,
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };

                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(strFrom, password)
                };
                smtpClient.Send(mailMessage);

                mailFrom = null;
                mailTo = null;
                smtpClient.Dispose();
                mailMessage.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}