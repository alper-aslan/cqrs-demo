using System;

namespace CQRS.Demo.BusinessLogic.Services.Mail
{
    public class MailMessage : IDisposable
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }

        public void Dispose()
        {
        }
    }
}