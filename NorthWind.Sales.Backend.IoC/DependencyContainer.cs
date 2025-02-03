using Microsoft.Extensions.DependencyInjection;
using Northwind.Sales.Backend.Presenters;
using Northwind.Sales.Backend.Repositories;
using NorthWind.Sales.Backend.Controllers;
using NorthWind.Sales.Backend.DataContext.EFCore;
using NorthWind.Sales.Backend.DataContext.EFCore.Options;
using NorthWind.Sales.Backend.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.IoC
{
    public static class DependencyContainer
    {
        // consumir AddSalesServices.
        public static IServiceCollection AddSalesServices(
            this IServiceCollection services,
            Action<DBOptions> configureDBOptions)
        {
            services.AddUseCasesServices()
                .AddRepositories()
                .AddDataSources(configureDBOptions)
                .AddPresenters()
                .AddSalesControllers();
            return services;
        }
    }
}
