
namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder
{
    public interface ICreateOrderController
    {
        Task<int> CreateOrder(CreateOrderDto order);
    }
}
