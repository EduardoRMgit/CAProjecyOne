using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.BusinessObjects.Repositories
{
    public interface IQueriesRepository
    {

        // si es nulo, el cliente no existe
        // devuelva nulo cuando el cliente no exista, va a devolver un valor cuando exista, y va a ser el saldo si existe.
        Task<decimal?>  GetCustomerCurrentBalance(string customerId);

        // si no existe en la lista, es que no existe en stock.
        Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(
            IEnumerable<int> productId);
    }
}
