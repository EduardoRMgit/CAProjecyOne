using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Backend.Controllers.CreateOrder;


namespace NorthWind.Sales.Backend.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSalesControllers(
            this IServiceCollection services)
        {

            services.AddScoped<ICreateOrderController, CreateOrderController>();
            return services;
        }
    }
}
