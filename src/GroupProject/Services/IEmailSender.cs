using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SendGrid;

namespace GroupProject.Services
{
    public class IEmailService
    { 
        public interface IEmailSender
        {
            Task SendEmailAsync(string email, string subject, string message);
        }

        //  email object 
        var myMessage = new SendGridMessage();

        //  message properties.
        myMessage.From = new MailAddress("john@example.com");

        // Add multiple addresses to the To field.
        List<String> recipients = new List<String>
{
    @"Jeff Smith <jeff@example.com>",
    @"Anna Lidman <anna@example.com>",
    @"Peter Saddow <peter@example.com>"
};

        myMessage.AddTo(recipients);

myMessage.Subject = "Testing the SendGrid Library";

//Add the HTML and Text bodies
myMessage.Html = "<p>You Have Been Invited to a new Event</p>";
myMessage.Text = "You Have been invited to a new event";
    }
}
