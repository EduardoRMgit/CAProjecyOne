using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Sales.Backend.Repositories.Interfaces;
using NorthWind.DomainLogs.EntityFrameworkCore;
using NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
using NorthWind.Sales.Backend.DataContext.EFCore.DataSources;
using NorthWind.Sales.Backend.DataContext.EFCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDataSources(
            this IServiceCollection services,
            Action<DBOptions> configureDBOptions)
        {
            var Options = new DBOptions();
            configureDBOptions(Options);
            services.AddDbContext<NorthWindSalesContext>(options =>
                                options.UseSqlServer(Options.ConnectionString));
            services.AddScoped<ICreateOrderRepositoryDataSource,
                CreateOrderRepositoryDataSoruce>();
            services.AddScoped<INorthWindSalesQueriesDataSource,
                NorthWindSalesQueriesDataSource>();

            services.AddLoggerServices(options =>
                options.UseSqlServer(Options.DomainLogsConnectionString));

            return services;
        }
    }
}
