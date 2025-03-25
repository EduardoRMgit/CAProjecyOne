using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;
using NorthWind.Sales.Backend.SmtpGateway.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.SmtpGateway
{

    // si quieres una instancia, necesitas un IOptions, porque no tiene comportamiento
    class MailService(IOptions<SmtpOptions> smtpOptions,
        ILogger<MailService> logger) : IMailService
    {

        public async Task SendEmailToAdministrator(string subject, string body)
        {

            try
            {
                MailMessage Message = new MailMessage(smtpOptions.Value.SenderEmail, smtpOptions.Value.AdministratorEmail)
                {
                    Subject = subject,
                    Body = body
                };

                SmtpClient Client = new SmtpClient(smtpOptions.Value.SmtpHost, smtpOptions.Value.SmtpHostPort)
                {
                    Credentials = new NetworkCredential(
                        smtpOptions.Value.SmtpUserName, smtpOptions.Value.SmtpPassword),
                    EnableSsl = true
                };

                await Client.SendMailAsync(Message);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}
