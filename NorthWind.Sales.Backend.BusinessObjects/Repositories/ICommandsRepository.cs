

namespace NorthWind.Sales.Backend.BusinessObjects.Repositories
{
    public interface ICommandsRepository: IUnitOfWork
    {
        Task CreateOrder(OrderAggregate order);
    }
}
