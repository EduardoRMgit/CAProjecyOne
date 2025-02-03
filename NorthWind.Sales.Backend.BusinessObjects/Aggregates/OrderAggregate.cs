

namespace NorthWind.Sales.Backend.BusinessObjects.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsFields = [];
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsFields;

        public void AddDetail(int productId, double unitPrice, short quantity)
        {
            // obtener el productID del objeto que me están pidiendo en productId.
            // Encuentra el primer objeto indicado y si no lo encuentra retorna default, el default de una clase es null
            var ExistingOrderDetail = OrderDetailsFields.FirstOrDefault(o => o.ProductId == productId);

            // si no es default, está repetido.
            if(ExistingOrderDetail != default)
            {
                quantity = ExistingOrderDetail.Quantity;
                OrderDetailsFields.Remove(ExistingOrderDetail);
            }

            OrderDetailsFields.Add(
                new OrderDetail(productId, unitPrice, quantity));
        }


        // Que hace este from? es un nombre de método => From
        // var X = OrderAggregate.From
        public static OrderAggregate From(CreateOrderDto orderDto)
        {
            // sintaxis de inicialización de objetos.
            OrderAggregate OrderAggregate = new OrderAggregate
            {
                CustomerId = orderDto.CustomerId,
                ShipAdress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipCountry = orderDto.ShipCountry,
                ShipPostalCode = orderDto.ShipPostalCode,
            };

            foreach(var item in orderDto.OrderDetailDtos)
            {
                OrderAggregate.AddDetail(item.ProductId,
                    item.UnitPrice, item.Quantity);
            }

            return OrderAggregate;
        }
    }


}
