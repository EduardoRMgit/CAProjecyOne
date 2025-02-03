
namespace NorthWind.Sales.Frontend.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSalesServices(
            this IServiceCollection services,
            Action<HttpClient> configureHttpClient)
        {
            services.addWebApiGateways(configureHttpClient).AddViewModels();
            return services;
        }
    }
}
