using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Backend.Repositories.Repositories.cs
{
    internal class CreateOrderRepository(
        ICreateOrderRepositoryDataSource dataSource): ICreateOrderRepository
    {

        public async Task CreateOrderAsync(OrderAggregate order)
        {
            await dataSource.AddOrderAsync(order);
            // le manda el oredr del order aggregate.
            await dataSource.AddOrderDetailsAsync(
                order.OrderDetails.Select(d => new Entities.OrderDetail
                {
                    Order = order,
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                }).ToArray());

        }

        public async Task SaveChangesAsync() => await dataSource.SaveChangesAsync();
        public Task BeginTransactionAsync() => dataSource.BeginTransactionAsync();

        public Task CommitAsync() => dataSource.CommitAsync();
        public Task RollbackAsync() => dataSource.RollbackAsync();


    }
}
