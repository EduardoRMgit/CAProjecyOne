using Microsoft.Extensions.DependencyInjection;
using Northwind.Sales.Backend.Presenters.CreateOrder;


namespace Northwind.Sales.Backend.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

            return services;
        }
    }
}
