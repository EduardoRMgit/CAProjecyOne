using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.ExceptionHandlers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddExceptionHandlers(
            this IServiceCollection services)
        {
            // las exepciones personalizadas se registran de la siguiente manera
            services.AddExceptionHandler<DomainValidationExceptionHandler>();
            services.AddExceptionHandler<CreateOrderExceptionHandler>();
            services.AddExceptionHandler<UnauthorizedAccessExceptionHandler>();

            return services;
        }
    }
}
