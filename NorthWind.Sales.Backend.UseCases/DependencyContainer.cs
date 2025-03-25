using Microsoft.Extensions.DependencyInjection;
using NorthWind.DomainEvents;
using NorthWind.DomainValidation.Interfaces;
using NorthWind.Sales.Backend.UseCases.CreateOrder;


namespace NorthWind.Sales.Backend.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();

            services.AddScoped<IDomainSpecification<CreateOrderDto>, CreateOrderCustomerSpecifications>();
            services.AddScoped<IDomainSpecification<CreateOrderDto>, CreateOrderProductSpecification>();

            services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>,  SendEmailWhenSpecialOrderCreatedEventHandler>();

            return services;
        }
    }
}
