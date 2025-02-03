namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects
{
    public class OrderDetail(int productId, double unitPrice, short quantity)
    {
        public int ProductId => productId;
        public double UnitPrice => unitPrice;
        public short Quantity => quantity;
    }
}
