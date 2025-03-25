using Microsoft.EntityFrameworkCore;
using Northwind.Sales.Backend.Repositories.Entities;
using NorthWind.Sales.Backend.BusinessObjects.Entities;
using System.Reflection;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataContexts
{
    internal class NorthWindSalesContext: DbContext
    {
        public NorthWindSalesContext(
            DbContextOptions<NorthWindSalesContext> options ): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Northwind.Sales.Backend.Repositories.Entities.OrderDetail> OrderDetails { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
