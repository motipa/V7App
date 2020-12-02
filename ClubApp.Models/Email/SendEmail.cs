using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.Email
{
    public class SendEmail
    {
        public string fromEmail { get; set; }
        public string toEmail { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
    }
}
