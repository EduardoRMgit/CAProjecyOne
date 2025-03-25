using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.BusinessObjects.Exceptions;

public class CreateOrderException: Exception
{
    public IReadOnlyList<string> Entities { get; }

    public CreateOrderException() { }

    public CreateOrderException(string message): base(message) { }

    public CreateOrderException(string message, Exception innerException) :
        base(message, innerException){}

    public CreateOrderException(Exception exception,
        IEnumerable<string> entities) : base(exception.Message, exception) =>
        Entities = [.. entities];
}
// Lanzar exepciones personalizadas, y agregar fixtures de los datos.