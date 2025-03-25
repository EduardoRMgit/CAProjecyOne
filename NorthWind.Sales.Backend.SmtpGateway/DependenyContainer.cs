using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;
using NorthWind.Sales.Backend.SmtpGateway.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.SmtpGateway
{
    public static class DependenyContainer
    {

        public static IServiceCollection AddSmtpMailService(this IServiceCollection services,
            Action<SmtpOptions> configureSmtpOptions)
        {
            services.AddSingleton<IMailService, MailService>();
            services.Configure(configureSmtpOptions);


            return services;
        }
    }
}
