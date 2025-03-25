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
    internal class DomainValidationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            bool Handled = false;

            if(exception is DomainValidationException Ex)
            {
                await httpContext.WriteProblemDetailsAsync(configure =>
                {
                    configure.Status = StatusCodes.Status400BadRequest;
                    configure.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                    configure.Title = ExceptionMessages.ValidationExceptionTitle;
                    configure.Detail = ExceptionMessages.ValidationExceptionDetail;

                    // la instancia es un uri con info adicional, TIPO DE LA EXEPCION QUE SE VA COMO INSTANCIA
                    configure.Instance =
                    $"{nameof(ProblemDetails)}";
                    // es un diccionario con llave texto, y valor cualquier objeto
                    configure.Extensions.Add("errors", Ex.Errors);
                });

                Handled = true;
            }


            return Handled;
        }
    }
}
