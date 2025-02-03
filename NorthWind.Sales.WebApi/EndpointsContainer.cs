using Microsoft.AspNetCore.Routing.Matching;
using Northwind.Sales.Entities.Dtos.CreateOrder;
using Northwind.Sales.Entities.ValueObjects;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

namespace NorthWind.Sales.WebApi
{
    public static class EndpointsContainer
    {
        public static IEndpointRouteBuilder MapSalesEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapPost(Endpoints.CreateOrder, async (CreateOrderDto order, ICreateOrderController controller) =>
                await controller.CreateOrder(order));
            return app;
        }
    }
}
