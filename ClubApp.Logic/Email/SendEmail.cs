using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Email
{
    public class SendEmail
    {
        public async Task<string> EmailSend(string To,string Subject,string Body)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(To + " <" + To + ">"));
                message.From = new MailAddress("Support Team <ssbbazaar2020@gmail.com>");
                //message.Bcc.Add(new MailAddress("Amit Mohanty <amitmohanty@email.com>"));
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("ssbbazaar2020@gmail.com", "ssb@2020");
                    await smtp.SendMailAsync(message);
                    await Task.FromResult(0);
                }
                return "Email Send";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
