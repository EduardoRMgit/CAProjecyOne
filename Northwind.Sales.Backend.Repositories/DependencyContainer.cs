using Microsoft.Extensions.DependencyInjection;
using Northwind.Sales.Backend.Repositories.Repositories.cs;

namespace Northwind.Sales.Backend.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<ICommandsRepository, CommandRepository>();
            return services;
        }
    }
}
