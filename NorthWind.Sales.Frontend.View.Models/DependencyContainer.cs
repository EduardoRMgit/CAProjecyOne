using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Frontend.View.Models.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Frontend.View.Models
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderViewModel>();

            return services;
        }
    }
}
