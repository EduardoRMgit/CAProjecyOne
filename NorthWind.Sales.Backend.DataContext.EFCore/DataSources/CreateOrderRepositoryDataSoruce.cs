using Microsoft.EntityFrameworkCore;
using Northwind.Sales.Backend.Repositories.Entities;
using Northwind.Sales.Backend.Repositories.Interfaces;
using NorthWind.DomainTransactions.EntityFrameworkCore;
using NorthWind.Sales.Backend.BusinessObjects.Entities;
using NorthWind.Sales.Backend.BusinessObjects.Exceptions;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
using NorthWind.Sales.Backend.DataContext.EFCore.DataContext;
using NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataSources
{
    internal class CreateOrderRepositoryDataSoruce(NorthWindSalesContext context) : TransactionHandlerBase(context.Database), ICreateOrderRepositoryDataSource
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
            try
            {
                await context.SaveChangesAsync();
            } // dominio del entity framework core
            catch (DbUpdateException ex)
            {
                // elemento del dominio
                throw new CreateOrderException(ex,
                    ex.Entries.Select(e => e.Entity.GetType().Name));
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}

