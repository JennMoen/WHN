using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using SendGrid;

namespace GroupProject.Services
{
    public class EmailService
    {
        public EmailService()
        {

        }

        
        public bool SendMessage(string[] to, string[] toNames, string from, string fromName, string subject, string text)
        {
            if (to.Length != toNames.Length)
                throw new Exception("\"to\" and \"toNames\" are not of equal length.");

            
          

            MailMessage mailMsg = new MailMessage();

            for (var i = 0; i < to.Length; i++)
                mailMsg.To.Add(new MailAddress(to[i], toNames[i]));

            mailMsg.From = new MailAddress("admin@whn.com", "WHN Admin");

            mailMsg.Subject = subject;

            

            string html = "<p>" + text + "</p>";

            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

            mailMsg.Headers.Add("X-SMTPAPI", "{\"filters\": { \"templates\": { \"settings\": { \"enable\": 1, \"template_id\": \"81840af1-bae1-4205-a616-4ce965274cea\"}}}}");
            

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(Startup.AdminEmailAddress, Startup.AdminEmailPw);
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);

            return true;
        }
    }
}