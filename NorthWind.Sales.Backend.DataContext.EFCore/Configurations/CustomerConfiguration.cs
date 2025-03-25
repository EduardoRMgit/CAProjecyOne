using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Sales.Backend.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore.Configurations
{
    internal class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(c => c.CurrentBalance)
               .HasPrecision(8, 2);

            builder.HasData(
                new Customer
                {
                    Id = "ALFKI",
                    Name = "Alfreds Fitterkiste",
                    CurrentBalance = 0
                },

                new Customer
                {
                    Id = "ANATR",
                    Name = "Ana Trujillo",
                    CurrentBalance = 0
                },

                new Customer
                {
                    Id = "ANTON",
                    Name = "Antoni Moreno",
                    CurrentBalance = 100
                }

                );

        }
    }
}
