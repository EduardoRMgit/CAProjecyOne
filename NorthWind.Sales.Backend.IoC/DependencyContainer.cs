using Microsoft.Extensions.DependencyInjection;
using Northwind.Sales.Backend.Presenters;
using Northwind.Sales.Backend.Repositories;
using Northwind.Sales.Entities;
using NorthWind.DomainEvents;
using NorthWind.DomainValidation;
using NorthWind.ExceptionHandlers;
using NorthWind.Sales.Backend.Controllers;
using NorthWind.Sales.Backend.DataContext.EFCore;
using NorthWind.Sales.Backend.DataContext.EFCore.Options;
using NorthWind.Sales.Backend.ExceptionHandlers;
using NorthWind.Sales.Backend.SmtpGateway;
using NorthWind.Sales.Backend.SmtpGateway.Options;
using NorthWind.Sales.Backend.UseCases;
using NorthWind.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.IoC
{
    // punto de contacto de la web api, agregar al unhandled exception handler, o dejarselo a la web api.
    public static class DependencyContainer
    {
        // consumir AddSalesServices.
        public static IServiceCollection AddSalesServices(
            this IServiceCollection services,
            Action<DBOptions> configureDBOptions,
            Action<SmtpOptions> configureSmtpOptions)
        {
            services.AddUseCasesServices()
                .AddRepositories()
                .AddDataSources(configureDBOptions)
                .AddPresenters()
                .AddSalesControllers()
                .AddDomainSpecificationsValidator()
                .AddDomainSpecifications()
                .AddExceptionHandlers()
                // aquí van todas las anteriores exepciones personalizadas

                .AddExceptionHandler<UnHandledExceptionHandler>()
                // hub de eventos de dominio
                .AddDomainEventHubService()

                // AGREGAR SERVICIO DE CORREO
                .AddSmtpMailService(configureSmtpOptions)
                //.AddUserServices()
                .AddAuthenticatedUserServicesFake()
                ;
            return services;
        }
    }
}
