

namespace NorthWind.Sales.Backend.UseCases.CreateOrder
{
    // Qué necesita?
    internal class CreateOrderInteractor(
        ICreateOrderOutputPort outputPort,
        ICommandsRepository repository) : ICreateOrderInputPort
    {
        public async Task Handle(CreateOrderDto order)
        {
            // tomar el dto y volverlo un agregado.
            OrderAggregate Order = OrderAggregate.From(order);

            await repository.CreateOrder(Order);
            await repository.SaveChanges();
            await outputPort.Handle(Order);
        }
    }
}
