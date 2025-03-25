using NorthWind.DomainTransactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Backend.Repositories.Interfaces
{
    public interface ICreateOrderRepositoryDataSource: ITransactionHandler
    {
        Task AddOrderAsync(Order order);
        Task AddOrderDetailsAsync(IEnumerable<Entities.OrderDetail> orderDetails);
        Task SaveChangesAsync();
    }
}
