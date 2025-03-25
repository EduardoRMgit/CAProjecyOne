using NorthWind.Sales.Backend.BusinessObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Backend.Repositories.Repositories.cs
{
    internal class QueriesRepository(INorthWindSalesQueriesDataSource dataSource) :
        IQueriesRepository
    {
        public async Task<decimal?> GetCustomerCurrentBalance(string customerId)
        {
            var Queryable = dataSource.Customers
                // el where quiere un delegado.
                .Where(c => c.Id == customerId)
                .Select(c => new {c.CurrentBalance });

            var Result = await dataSource.FirstOrDefaultAsync(Queryable);

            return Result?.CurrentBalance;
        }

        public async Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds)
        {
            var Queryable = dataSource.Products
                .Where(p => productIds.Contains(p.Id))
                .Select(p => new ProductUnitsInStock(p.Id, p.UnitsInStock));

            return await dataSource.ToListAsync(Queryable);
        }
    }
}
