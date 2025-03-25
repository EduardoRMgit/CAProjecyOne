using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthWind.DomainValidation.Exceptions;
using NorthWind.ExceptionHandlers.Extensions;
using NorthWind.Sales.Backend.BusinessObjects.Exceptions;
using NorthWind.Sales.Backend.ExceptionHandlers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.ExceptionHandlers
{
    internal class CreateOrderExceptionHandler(
        ILogger<CreateOrderExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            bool Handled = false;

            if(exception is CreateOrderException Ex)
            {
                await httpContext.WriteProblemDetailsAsync(configure =>
                {
                    configure.Status = StatusCodes.Status500InternalServerError;
                    configure.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                    configure.Title = ExceptionMessages.CreateOrderExceptionTitle;
                    configure.Detail = ExceptionMessages.CreateOrderExceptionDetail;

                    // la instancia es un uri con info adicional, TIPO DE LA EXEPCION QUE SE VA COMO INSTANCIA
                    configure.Instance =
                    $"{nameof(ProblemDetails)}/{nameof(CreateOrderException)}";
                    // es un diccionario con llave texto, y valor cualquier objeto
                });

                logger.LogError(exception, ExceptionMessages.CreateOrderExceptionTitle + ": " + string.Join(" ", Ex.Entities));
                Handled = true;
            }


            return Handled;
        }
    }
}
