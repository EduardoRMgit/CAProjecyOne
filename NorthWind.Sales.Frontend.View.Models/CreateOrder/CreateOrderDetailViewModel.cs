using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Frontend.View.Models.CreateOrder
{
    public class CreateOrderDetailViewModel
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public short Quantity { get; set; }

    }
}
