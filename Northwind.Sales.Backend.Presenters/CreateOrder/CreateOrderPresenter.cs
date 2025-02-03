

namespace Northwind.Sales.Backend.Presenters.CreateOrder
{
    internal class CreateOrderPresenter : ICreateOrderOutputPort
    {
        // solo lectura hacia al exterior
        public int OrderId { get; private set; }

        // retornar.
        public Task Handle(OrderAggregate addedOrder)
        {
            OrderId = addedOrder.Id;
            return Task.CompletedTask;
        }
    }
}
