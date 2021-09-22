using System;

namespace CQRS.Demo.BusinessLogic.Services.Mail
{
    public class MySmtpClient : IDisposable
    {
        public void Send(MailMessage message)
        {
            Console.WriteLine($"Smtp Client: Send mail: {message}");
        }

        public void Dispose()
        {
        }
    }
}
