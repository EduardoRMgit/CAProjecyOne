using Northwind.Sales.Entities.Dtos.CreateOrder;


namespace NorthWind.Sales.Frontend.BusinessObjects.Interfaces
{
    // este gateway me permite consumir el api
    public interface ICreateOrderGateway
    {
        // necesito enviarle el DTO para crear una orden
        Task<int> CreateOrderAsync(CreateOrderDto order);
    }
}
