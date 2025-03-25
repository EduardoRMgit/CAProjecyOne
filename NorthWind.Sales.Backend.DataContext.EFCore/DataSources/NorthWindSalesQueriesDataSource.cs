using Microsoft.EntityFrameworkCore;
using Northwind.Sales.Backend.Repositories.Entities;
using Northwind.Sales.Backend.Repositories.Interfaces;
using NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataSources
{
    internal class NorthWindSalesQueriesDataSource : INorthWindSalesQueriesDataSource
    {
        readonly NorthWindSalesContext Context;

        public NorthWindSalesQueriesDataSource(NorthWindSalesContext context)
        {
            Context = context;
            context.ChangeTracker.QueryTrackingBehavior =
                QueryTrackingBehavior.NoTracking;
        }


        IQueryable<Customer> INorthWindSalesQueriesDataSource.Customers =>
            Context.Customers;

        IQueryable<Product> INorthWindSalesQueriesDataSource.Products =>
            Context.Products;

        Task<ReturnType> INorthWindSalesQueriesDataSource.FirstOrDefaultAsync<ReturnType>(IQueryable<ReturnType> queryable)
            => queryable.FirstOrDefaultAsync();

        async Task<IEnumerable<ReturnType>> INorthWindSalesQueriesDataSource.ToListAsync<ReturnType>(
            IQueryable<ReturnType> queryable) => await queryable.ToListAsync();

    }
}
