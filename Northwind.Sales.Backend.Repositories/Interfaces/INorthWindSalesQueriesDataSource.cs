using Northwind.Sales.Backend.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Backend.Repositories.Interfaces
{
    public interface INorthWindSalesQueriesDataSource
    {
        IQueryable<Customer> Customers { get;  }
        IQueryable<Product> Products { get; }


        Task<ReturnType> FirstOrDefaultAsync<ReturnType>(
            IQueryable<ReturnType> queryable);


        Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
            IQueryable<ReturnType> queryable);

    }
}
