using Microsoft.Extensions.DependencyInjection;
using NorthWind.DomainValidation.Interfaces;
using Northwind.Sales.Entities.Dtos.CreateOrder;
using Northwind.Sales.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Entities
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDomainSpecifications(
            this IServiceCollection services)
        {
            services.AddScoped<
                IDomainSpecification<CreateOrderDetailDto>,
                CreateOrderDetailDtoSpecification
                >();

            services.AddScoped<
                IDomainSpecification<CreateOrderDto>,
                CreateOrderDtoSpecification
                >();

            return services;

        }
    }
}
