using NorthWind.DomainTransactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder
{
    public interface ICreateOrderRepository : ITransactionHandler
    {
        Task CreateOrderAsync(OrderAggregate order);
        Task SaveChangesAsync();
    }
}
