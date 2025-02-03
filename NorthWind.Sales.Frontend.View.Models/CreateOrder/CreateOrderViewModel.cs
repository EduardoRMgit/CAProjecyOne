using Northwind.Sales.Entities.Dtos.CreateOrder;
using NorthWind.Sales.Frontend.BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Frontend.View.Models.CreateOrder
{
    public class CreateOrderViewModel(ICreateOrderGateway gateway)
    {
        // no tengo el order ID, esto es lo único capturable.
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = [];

        // se ha creado la orden, que tome el dato de la orden ahí
        public int OrderId { get; private set; }

        public void AddNewOrderDetailItem()
        {
            OrderDetails.Add(new CreateOrderDetailViewModel());
        }


        public async Task Send()
        {
            // no puedo convertir el view model en un DTO
            OrderId = await gateway.CreateOrderAsync((CreateOrderDto)this);
        }

        // explicit => cast

        // CONVERTIR UN VIEW MODEL EN UN DTO.
        public static explicit operator CreateOrderDto(CreateOrderViewModel model) => new CreateOrderDto(
            model.CustomerId, model.ShipAddress, model.ShipCity, model.ShipCountry,model.ShipPostalCode,
            model.OrderDetails.Select(d => new CreateOrderDetailDto(
                d.ProductId, d.UnitPrice, d.Quantity)));
    }
}
