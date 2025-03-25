using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.DomainValidation.Exceptions;
using NorthWind.ExceptionHandlers.Extensions;
using NorthWind.Sales.Backend.ExceptionHandlers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.ExceptionHandlers
{
    internal class UnauthorizedAccessExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            bool Handled = false;

            if(exception is UnauthorizedAccessException Ex)
            {
                await httpContext.WriteProblemDetailsAsync(configure =>
                {
                    configure.Status = StatusCodes.Status401Unauthorized;
                    configure.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                    configure.Title = ExceptionMessages.UnauthorizedAccessExceptionTitle;
                    configure.Detail = ExceptionMessages.UnauthorizedAccessExceptionDetail;

                    // la instancia es un uri con info adicional, TIPO DE LA EXEPCION QUE SE VA COMO INSTANCIA
                    configure.Instance =
                    $"{nameof(ProblemDetails)}/{nameof(UnauthorizedAccessException)}";
                    // es un diccionario con llave texto, y valor cualquier objeto
                });

                Handled = true;
            }


            return Handled;
        }
    }
}
