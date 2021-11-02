using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {
            
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute("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", subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("tutorbuddy@protonmail.com", "Admin"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
