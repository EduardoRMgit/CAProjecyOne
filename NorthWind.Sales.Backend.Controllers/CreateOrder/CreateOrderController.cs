
namespace NorthWind.Sales.Backend.Controllers.CreateOrder
{
    internal class CreateOrderController(
        ICreateOrderInputPort inputPort,
        ICreateOrderOutputPort outputPort) : ICreateOrderController
    {
        public async Task<int> CreateOrder(CreateOrderDto order)
        {
            await inputPort.Handle(order);
            return outputPort.OrderId;
        }
    }
}
