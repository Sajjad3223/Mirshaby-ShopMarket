using System.Net.Mail;
using ShopMarket.Core.Interfaces;

namespace ShopMarket.Core.Utilities.Sernders
{
    public class GmailSender : IEmailSender
    {
        public void Send(string To,string Subject,string Body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("ShopMarket.ir@gmail.com","شاپ مارکت");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("shopmarket1400@gmail.com", "-ptVNUEG!gSyHy7");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}