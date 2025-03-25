using Microsoft.Extensions.DependencyInjection;
using Northwind.Sales.Backend.Repositories.Repositories.cs;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

namespace Northwind.Sales.Backend.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderRepository, CreateOrderRepository>();
            services.AddScoped<IQueriesRepository, QueriesRepository>();

            return services;
        }
    }
}
