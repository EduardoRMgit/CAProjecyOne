﻿namespace NorthWind.Sales.Backend.BusinessObjects.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ShipAdress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public ShippingType ShippingType { get; set; } = ShippingType.Road;
        public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
        public double Discount { get; set; } = 10;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
