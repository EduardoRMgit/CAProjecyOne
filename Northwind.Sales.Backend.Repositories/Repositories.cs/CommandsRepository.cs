
namespace Northwind.Sales.Backend.Repositories.Repositories.cs
{
    public class CommandRepository(INorthWindSalesCommandsDataSource dataSource): ICommandsRepository
    {
        public async Task CreateOrder(OrderAggregate order)
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

        //explicitamente, el cliente tiene que invocar al método saveChanges para que la persistencia se realize().
        public async Task SaveChanges()
        {
            await dataSource.SaveChangesAsync();
        }
    }
}
