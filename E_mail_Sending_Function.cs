using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication2.E_mail_Sending
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public async Task SendAsync(String toEmail, String subject, String contents, String FP, String cc)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("SmartTravel@localhost.com");
            var to = new List<EmailAddress>
            {
                new EmailAddress(cc,""),
                new EmailAddress(toEmail,""),
            };
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var showAllRecipients = false;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent, showAllRecipients);
            if (FP != null)
            {
                string fullPath = Path.Combine("/Users/PX Hao/source/repos/WebApplication2/File Saved", FP);
                string fileName = Path.GetFileName(fullPath);
                string type = Path.GetExtension(fullPath);
                var bytes = File.ReadAllBytes(fullPath);
                var file02 = Convert.ToBase64String(bytes);
                msg.AddAttachment(fileName, file02, type);
            }
            var response = await client.SendEmailAsync(msg);
        }
    }
}