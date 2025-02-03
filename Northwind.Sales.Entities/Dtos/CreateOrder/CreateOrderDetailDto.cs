
namespace Northwind.Sales.Entities.Dtos.CreateOrder;

public class CreateOrderDetailDto(int productId, double unitPrice, short quantity)
{
    public int ProductId => productId;
    public double UnitPrice => unitPrice;
    public short Quantity => quantity;
}
