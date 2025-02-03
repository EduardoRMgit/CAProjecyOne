using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Backend.Repositories.Interfaces
{
    // fuente de datos para comandos
    // con entity framework core, ya me hubiera ahorrado esta abstracción.
    public interface INorthWindSalesCommandsDataSource
    {
        Task AddOrderAsync(Order order);

        Task AddOrderDetailsAsync(IEnumerable<Entities.OrderDetail> orderDetails);

        Task SaveChangesAsync();
    }
}
