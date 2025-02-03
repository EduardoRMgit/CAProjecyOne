using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Sales.Backend.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // POR CONVENCIÓN, TOMA EL ID.
            builder.Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();

            builder.Property(o => o.ShipAdress)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(o => o.ShipCity)
                .HasMaxLength(15);

            builder.Property(o => o.ShipCountry)
                .HasMaxLength(15);

            builder.Property(o => o.ShipPostalCode)
                .HasMaxLength(10);



        }
    }
}
