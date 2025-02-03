using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Sales.Backend.Repositories.Entities;

namespace NorthWind.Sales.Backend.DataContext.EFCore.Configurations
{
    internal class OrderDetailConfiguration :
        IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(d => new { d.OrderId, d.ProductId }); // => orderid + product ID
            builder.Property(d => d.UnitPrice)
                .HasPrecision(8, 2);
        }
    }
}
