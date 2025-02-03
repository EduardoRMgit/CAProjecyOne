using Northwind.Sales.Backend.Repositories.Entities;
using Northwind.Sales.Backend.Repositories.Interfaces;
using NorthWind.Sales.Backend.BusinessObjects.Entities;
using NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataSources
{
    internal class NorthWindSalesCommandsDataSource(
        NorthWindSalesContext context): INorthWindSalesCommandsDataSource
    {
        public async Task AddOrderAsync(Order order)
        {
            await context.AddAsync(order);
        }

        public async Task AddOrderDetailsAsync(IEnumerable<OrderDetail> orderDetails)
        {
            await context.AddRangeAsync(orderDetails);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
