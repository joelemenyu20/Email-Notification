using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCL.Control
{
    public class Logic
    {
        public string myMessage;
        
        public void SendEmailNotification()
        {
            string meetingTitle = "BEGINNING OF MONTH MEETING";
            DateTime meetingTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 0, 0);
            string emailBody = GenerateEmailBody(meetingTime, meetingTitle);
            using (MailMessage message = new MailMessage())
            {
                message.To.Clear();
                message.To.Add(new MailAddress("test@gmail.com"));
                message.CC.Add(new MailAddress(""));
                message.Body = emailBody;
                message.Subject = "MEETING REMINDER";
                message.From = new MailAddress("test@gmail.com");

                using (SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.EnableSsl = true;
                    mailClient.Credentials = new NetworkCredential("your_gmail_account@gmail.com", "your_gmail_password");
                    mailClient.Timeout = 450000;
                    mailClient.Send(message);
                }
            }
        }
        private string GenerateEmailBody(DateTime meetingTime, string meetingTitle)
        {
            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine($"Hello,");
            emailBody.AppendLine();
            emailBody.AppendLine($"This is a reminder for the following meeting:");
            emailBody.AppendLine($"Meeting Title: {meetingTitle}");
            emailBody.AppendLine($"Meeting Time: {meetingTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            emailBody.AppendLine();
            emailBody.AppendLine("Please make sure to attend this meeting.");
            emailBody.AppendLine();
            emailBody.AppendLine("Best regards,");
            emailBody.AppendLine("Christine");

            return emailBody.ToString();
        }
    }
}
